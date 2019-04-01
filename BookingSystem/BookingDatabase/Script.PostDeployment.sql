/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF (NOT EXISTS(SELECT * FROM [dbo].[Roles]))
BEGIN
	INSERT INTO Roles ([Name])
	VALUES
		('Admin'),
		('User');
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Countries]))
BEGIN
    INSERT INTO [dbo].[Countries]([Name]) 
	VALUES ('United States'), ('United Kingdom'), ('Spain')
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Cities]))
BEGIN
	INSERT INTO [dbo].[Cities]([CountryId], [Name])
	SELECT [Countries].[CountryId], [Cities].[Name]
	FROM (SELECT [CountryId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
		  FROM [dbo].[Countries]) AS [Countries]
	JOIN 
		(SELECT [Name], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num
		 FROM (VALUES ('New York'),('London'),('Madrid')) AS [Cities]([Name])) AS [Cities]
	ON [Countries].row_num = [Cities].row_num
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAvailableHotels] 
	@LockTime TINYINT= 30,
	@MoveInDate DATETIME2 = NULL, 
	@MoveOutDate DATETIME2 = NULL,
	@Name NVARCHAR(80) = NULL,
	@IsActive BIT = NULL,
	@CountryId INT = NULL,
	@CityId INT = NULL,
	@RoomSize TINYINT = NULL,
	@PageSize INT = 10,
	@Page INT = 1,
	@TotalPages INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ItemsCount INT = 0;
	DECLARE @Pending TINYINT = 1;
	DECLARE @Failed TINYINT = 3;
	DECLARE @FilteredHotels TABLE 
		                    (HotelId INT NOT NULL,
							 BookingsAmount INT);

	WITH 
	FilteredRooms AS 
	(SELECT Rooms.* FROM Rooms 
	WHERE @RoomSize IS NULL OR Rooms.Size = @RoomSize),

        AvailableHotels AS
	(SELECT Rooms.HotelId as HotelId, COUNT(Bookings.BookingID) as BookingsAmount
	FROM FilteredRooms AS Rooms
	LEFT JOIN Bookings ON Bookings.RoomId = Rooms.RoomId
	WHERE (Bookings.BookingId IS NULL OR 
		  (@MoveInDate > Bookings.MoveOutDate) OR
		  (@MoveInDate < Bookings.MoveInDate) OR
		  (Bookings.Status = @Failed) OR (Bookings.Status = @Pending AND
		  DATEADD(Minute, @LockTime, Bookings.CreatedDate) > SYSDATETIME()))
	GROUP BY Rooms.RoomId, Rooms.Quantity, Rooms.HotelId
	HAVING COUNT(Bookings.BookingId) < Rooms.Quantity),

	DistinctAvailableHotels AS
	(SELECT Hotels.HotelId, SUM(Hotels.BookingsAmount) as BookingsAmount FROM AvailableHotels as Hotels
	 GROUP BY Hotels.HotelId)

	INSERT INTO @FilteredHotels
	SELECT Hotels.HotelId, DistinctAvailableHotels.BookingsAmount 
	FROM Hotels
	JOIN DistinctAvailableHotels ON DistinctAvailableHotels.HotelId = Hotels.HotelId
	WHERE (@CityId IS NULL OR Hotels.CityId = @CityId) AND 
		  (@CountryId IS NULL OR Hotels.CountryId = @CountryId) AND 
		  (@IsActive IS NULL OR Hotels.IsActive = @IsActive) AND 
		  (@Name IS NULL OR Hotels.Name = @Name)

	SELECT @ItemsCount = Count(HotelId) FROM @FilteredHotels;
	SELECT @TotalPages = (@ItemsCount + @PageSize - 1) / @PageSize;

	WITH 
	PaginatedHotelsId AS
	(SELECT Hotels.HotelId  FROM @FilteredHotels as Hotels
	ORDER BY Hotels.BookingsAmount DESC
	OFFSET (@Page-1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY)

	SELECT Hotels.HotelId, Hotels.Name, Hotels.Address, Hotels.IsActive, 
		   Cities.Name as CityName, Countries.Name as CountryName, HotelImage.URL as ImageUrl
	FROM Hotels
	JOIN PaginatedHotelsId ON PaginatedHotelsId.HotelId = Hotels.HotelId
	LEFT JOIN 
	  (SELECT Images.URL, HotelImage.HotelId FROM Images
	  JOIN (SELECT HotelImages.HotelId, MIN(HotelImages.ImageId) AS ImageId FROM HotelImages 
			JOIN Hotels ON Hotels.HotelId = HotelImages.HotelId -- may i rm that ?
			GROUP BY HotelImages.HotelId) AS HotelImage 
	  ON HotelImage.ImageId = Images.ImageId) AS HotelImage
        ON HotelImage.HotelId = Hotels.HotelId
	JOIN Cities on Cities.CityId = Hotels.CityId
	JOIN Countries on Countries.CountryId = Hotels.CountryId;
	
END
