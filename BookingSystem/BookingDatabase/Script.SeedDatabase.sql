IF (NOT EXISTS(SELECT * FROM [dbo].[Users]))
BEGIN
    INSERT INTO [Users]
			([FirstName], [SecondName], [Email], [PasswordHash])
	VALUES
		('admin', 'admin', 'admin@admin.com', '1'),
		('user', 'user', 'user@user.com', '2');
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Hotels]))
BEGIN
	INSERT INTO [dbo].[Hotels]([Name],[Address],[CountryId], [CityId])
	SELECT [Hotels].[Name], [Addresses].[Address], [Cities].[CountryId], [Cities].[CityId]
	FROM (SELECT [Name], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
		  FROM (VALUES ('Moderne Hotel'), ('The County'), ('Madrid Plaza')) AS [Hotels]([Name])) AS [Hotels]
	JOIN 
		(SELECT [CityId], [CountryId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
		 FROM [dbo].[Cities]) AS [Cities]
	ON [Hotels].row_num = [Cities].row_num
	JOIN 
		(SELECT [Address], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num
		 FROM 
		 (VALUES ('243 West 55th St., New York, NY 10019'),
		 		 ('83-95 Southampton Row, London WC1B 4HD'),
				 ('Calle Gran Vía, 74 Madrid')) 
		 AS [Addresses]([Address])) AS [Addresses]
	ON [Addresses].row_num = [Hotels].row_num
END


DECLARE @FirstHotelId INT, @SecondHotelId INT;
SET @FirstHotelId = (SELECT [HotelId] FROM [dbo].[Hotels] WHERE [Name] = 'Moderne Hotel');
SET @SecondHotelId = (SELECT [HotelId] FROM [dbo].[Hotels] WHERE [Name] = 'The County');

PRINT 'FIRST HOTEL ID: '
PRINT CAST(@FirstHotelId AS NVARCHAR);

IF (NOT EXISTS(SELECT * FROM [dbo].[Rooms]))
BEGIN
	INSERT INTO [dbo].Rooms([HotelId], [Name], [Price], [Size], [Quantity])
	VALUES
		(@FirstHotelId,'room for 1 person', 10.0, 1, 10),
		(@SecondHotelId, 'room for 3 persons', 20.0, 2, 20);
END


IF (NOT EXISTS(SELECT * FROM [dbo].[ExtraServices]))
BEGIN
	INSERT INTO [dbo].[ExtraServices]([Name],[Price], [HotelId])
	VALUES
		('car place', 20.0, @FirstHotelId),
		('car place', 40.0, @SecondHotelId);
END


IF (NOT EXISTS(SELECT * FROM [dbo].[Bookings]))
BEGIN
	DECLARE @UserId INT;
	SET @UserId = (SELECT [UserId] FROM  [dbo].[Users] WHERE [FirstName]='user');
	
	DECLARE @FirstRoomId INT;
	DECLARE @SecondRoomId INT;
	SET @FirstRoomId = (SELECT [RoomId] FROM [dbo].[Rooms] WHERE [Name] = 'room for 1 person');
	SET @SecondRoomId = (SELECT [RoomId] FROM [dbo].[Rooms] WHERE [Name] = 'room for 3 persons');

	INSERT INTO [dbo].[Bookings]([RoomId], [UserId], [CreatedDate], [MoveInDate], [MoveOutDate], [Status])
	VALUES
	(@FirstRoomId, @UserId, SYSDATETIME(), SYSDATETIME(), SYSDATETIME(), 1),
	(@SecondRoomId , @UserId, SYSDATETIME(), SYSDATETIME(), SYSDATETIME(), 1);
END


