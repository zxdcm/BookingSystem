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


IF (EXISTS(SELECT * FROM [dbo].[Users]))
BEGIN
    DELETE FROM [dbo].[Users]
END

IF (EXISTS(SELECT * FROM [dbo].[Roles]))
BEGIN
    DELETE FROM [dbo].[Roles]
END

IF (EXISTS(SELECT * FROM [dbo].[Bookings]))
BEGIN
    DELETE FROM [dbo].[Bookings]
END

IF (EXISTS(SELECT * FROM [dbo].[BookingExtraServices]))
BEGIN
    DELETE FROM [dbo].[BookingExtraServices]
END

IF (EXISTS(SELECT * FROM [dbo].[ExtraServices]))
BEGIN
    DELETE FROM [dbo].[ExtraServices]
END

IF (EXISTS(SELECT * FROM [dbo].[RoomNumbers]))
BEGIN
    DELETE FROM [dbo].[RoomNumbers]
END

IF (EXISTS(SELECT * FROM [dbo].[Rooms]))
BEGIN
    DELETE FROM [dbo].[Rooms]
END

IF (EXISTS(SELECT * FROM [dbo].[Hotels]))
BEGIN
    DELETE FROM [dbo].[Hotels]
END


IF (EXISTS(SELECT * FROM [dbo].[Locations]))
BEGIN
    DELETE FROM [dbo].[Locations]
END

IF (EXISTS(SELECT * FROM [dbo].[Cities]))
BEGIN
    DELETE FROM [dbo].[Cities]
END

IF (EXISTS(SELECT * FROM [dbo].[Countries]))
BEGIN
    DELETE FROM [dbo].[Countries]
END


INSERT INTO [Users]
			([FirstName], [SecondName], [Email], [PasswordHash], [PasswordSalt])
VALUES
	('admin', 'admin', 'admin@admin.com', '1', '1'),
	('user', 'user', 'user@user.com', '2', '1');


INSERT INTO Roles ([Name])
VALUES
	('Admin'),
	('User');




INSERT INTO [dbo].[Countries]([Name]) 
VALUES ('United States'), ('United Kingdom'), ('Spain')

INSERT INTO [dbo].[Cities]([CountryId], [Name])
SELECT [Countries].[CountryId], [Cities].[Name]
FROM (SELECT [CountryId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
	  FROM [dbo].[Countries]) AS [Countries]
JOIN 
	(SELECT [Name], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num
	 FROM (VALUES ('New York'),('London'),('Madrid')) AS [Cities]([Name])) AS [Cities]
ON [Countries].row_num = [Cities].row_num


INSERT INTO [dbo].[Hotels]([Name],[Address],[CountryId], [CityId])
SELECT [Hotels].[Name], [Addresses].[Address], [Countries].CountryId, [Cities].[CityId]
FROM (SELECT [Name], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
	  FROM (VALUES ('Moderne Hotel'), ('The County'), ('Madrid Plaza')) AS [Hotels]([Name])) AS [Hotels]
JOIN 
	(SELECT [CityId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
	 FROM [dbo].[Cities]) AS [Cities]
ON [Hotels].row_num = [Cities].row_num
JOIN 
	(SELECT [CountryId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
	 FROM [dbo].[Countries]) AS [Countries]
ON [Countries].row_num = [Hotels].row_num
JOIN 
	(SELECT [Address], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num
	 FROM 
	 (VALUES ('243 West 55th St., New York, NY 10019'),
		 	 ('83-95 Southampton Row, London WC1B 4HD'),
		     ('Calle Gran Vía, 74 Madrid')) 
	 AS [Addresses]([Address])) AS [Addresses]
ON [Addresses].row_num = [Hotels].row_num


DECLARE @FirstHotelId INT, @SecondHotelId INT;
SET @FirstHotelId = (SELECT [HotelId] FROM [dbo].[Hotels] WHERE [Name] = 'Moderne Hotel');
SET @SecondHotelId = (SELECT [HotelId] FROM [dbo].[Hotels] WHERE [Name] = 'The County');

PRINT cast(@FirstHotelId as varchar);
PRINT cast(@SecondHotelId as varchar);

INSERT INTO [dbo].Rooms([HotelId], [Name], [Price], [Size])
VALUES
	(@FirstHotelId,'room for 1 person', 10.0, 1),
	(@SecondHotelId, 'room for 3 persons', 20.0, 2);


DECLARE @FirstRoomId INT, @SecondRoomID INT;
SET @FirstRoomId = (SELECT [RoomId] FROM [dbo].[Rooms] WHERE [HotelId] = @FirstHotelId);
SET @SecondRoomID = (SELECT [RoomId] FROM [dbo].[Rooms] WHERE [HotelId] = @SecondHotelId);


INSERT INTO [dbo].[RoomNumbers]([Number], [IsAvailable], [RoomId])
VALUES
	(1, 1, @FirstRoomId),
	(2, 1, @FirstRoomId),
	(3, 1, @FirstRoomId);


INSERT INTO [dbo].[ExtraServices]([Name],[Price], [HotelId])
VALUES
	('car place', 20.0, @FirstHotelId),
	('car place', 40.0, @SecondHotelId);

DECLARE @UserId INT;
SET @UserId = (SELECT [UserId] FROM  [dbo].[Users] WHERE [FirstName]='user');
	
DECLARE @FirstRoomNumberId INT;
DECLARE @SecondRoomNumberId INT;
SET @FirstRoomNumberId = (SELECT [RoomNumberId] FROM [dbo].[RoomNumbers] WHERE [Number] = 1);
SET @SecondRoomNumberId = (SELECT [RoomNumberId] FROM [dbo].[RoomNumbers] WHERE [Number] = 2);

INSERT INTO [dbo].[Bookings](RoomNumberId, UserId, CreatedDate, Status)
VALUES
	(@FirstRoomNumberId, @UserId, SYSDATETIME(), 1),
	(@SecondRoomNumberId, @UserId, SYSDATETIME(), 1);

