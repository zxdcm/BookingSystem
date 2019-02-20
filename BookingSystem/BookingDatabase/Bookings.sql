CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Created] DATETIME2 NOT NULL,
	[MoveIn] DATETIME2,
	[MoveOut] DATETIME2,
	[TotalPrice] DECIMAL(18, 4),
	[Status] TINYINT NOT NULL,
	[RoomNumberId] INT NOT NULL,
	[UserId] INT NOT NULL,
    CONSTRAINT FK_BookingRoomNumber FOREIGN KEY([RoomNumberId]) REFERENCES RoomNumbers(RoomNumberId),
	CONSTRAINT FK_BookingUser FOREIGN KEY([UserId]) REFERENCES Users(UserId),
)
