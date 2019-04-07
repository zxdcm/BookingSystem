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
	@LockTime TINYINT = 30,
	@MoveInDate DATETIME2 = NULL, 
	@MoveOutDate DATETIME2 = NULL,
	@Name NVARCHAR(80) = NULL,
	@IsActive BIT = NULL,
	@CountryId INT = NULL,
	@CityId INT = NULL,
	@RoomSize TINYINT = NULL,
	@PageSize INT = 10,
	@Page INT = 1,
	@TotalItems INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Pending TINYINT = 1;
	DECLARE @Failed TINYINT = 3;
	DECLARE @FilteredHotels TABLE 
                             (HotelId INT NOT NULL,
							 Name NVARCHAR(80), 
							 Address NVARCHAR(80), 
							 IsActive BIT, 
							 CityName NVARCHAR(80), 
							 CountryName NVARCHAR(80), 
							 ImageUrl NVARCHAR(80),
							 BookingsAmount INT);

	IF @Page < 1
		SET @Page = 1;
	IF @PageSize < 1
		SET @PageSize = 1;

	WITH 
	AvailableHotels AS
	(SELECT Rooms.HotelId AS HotelId,
		    COUNT(Bookings.BookingID) AS BookingsAmount
 	FROM Rooms
	LEFT JOIN Bookings ON Bookings.RoomId = Rooms.RoomId
	WHERE ((@RoomSize IS NULL OR Rooms.Size = @RoomSize) AND
          ((Bookings.BookingId IS NULL) OR 
		  (@MoveInDate > Bookings.MoveOutDate) OR
		  (@MoveOutDate < Bookings.MoveInDate) OR
		  (Bookings.Status = @Failed) OR 
		  (Bookings.Status = @Pending AND DATEADD(Minute, @LockTime, Bookings.CreatedDate) > SYSDATETIME())))
	GROUP BY Rooms.RoomId,
		     Rooms.Quantity, 
		     Rooms.HotelId
	HAVING COUNT(Bookings.BookingId) < Rooms.Quantity),

	DistinctAvailableHotels AS
	(SELECT Hotels.HotelId, 
	        SUM(Hotels.BookingsAmount) AS BookingsAmount
	 FROM AvailableHotels AS Hotels
	 GROUP BY Hotels.HotelId)

	INSERT INTO @FilteredHotels 
	SELECT Hotels.HotelId,
	        Hotels.Name, 
			Hotels.Address, 
			Hotels.IsActive, 
		    Cities.Name AS CityName, 
			Countries.Name AS CountryName, 
			HotelImage.URL AS ImageUrl,
			DistinctAvailableHotels.BookingsAmount
	FROM Hotels
	JOIN DistinctAvailableHotels ON DistinctAvailableHotels.HotelId = Hotels.HotelId
	LEFT JOIN 
	(SELECT Images.URL, 
	        HotelImage.HotelId 
	 FROM Images
	 JOIN (SELECT HotelImages.HotelId, 
		   MIN(HotelImages.ImageId) AS ImageId 
		   FROM HotelImages 
		   JOIN DistinctAvailableHotels ON DistinctAvailableHotels.HotelId = HotelImages.HotelId -- rm?
		   GROUP BY HotelImages.HotelId) AS HotelImage 
	 ON HotelImage.ImageId = Images.ImageId) AS HotelImage
	ON HotelImage.HotelId = Hotels.HotelId
	JOIN Cities on Cities.CityId = Hotels.CityId
	JOIN Countries on Countries.CountryId = Hotels.CountryId
	WHERE (@CityId IS NULL OR Hotels.CityId = @CityId) AND 
		  (@CountryId IS NULL OR Hotels.CountryId = @CountryId) AND 
		  (@IsActive IS NULL OR Hotels.IsActive = @IsActive) AND 
		  (@Name IS NULL OR Hotels.Name = @Name);

	SELECT @TotalItems = Count(HotelId) 
	FROM @FilteredHotels;
	
	SELECT Hotels.HotelId,
		   Hotels.Name,
		   Hotels.Address, 
		   Hotels.IsActive, 
		   CityName, 
		   CountryName,
		   ImageUrl
    FROM @FilteredHotels as Hotels
	ORDER BY Hotels.BookingsAmount DESC
	OFFSET (@Page-1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY

END