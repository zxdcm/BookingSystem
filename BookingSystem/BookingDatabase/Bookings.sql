CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT NOT NULL PRIMARY KEY,
	[Created] DATETIME2 NOT NULL,
	[MoveIn] DATETIME2 NOT NULL,
	[MoveOut] DATETIME2 NOT NULL,
	[TotalPrice] DECIMAL NOT NULL,
	[Status] TINYINT NOT NULL,
	[RoomNumberId] INT NOT NULL,
	[UserId] INT NOT NULL,
    CONSTRAINT FK_BookingRoomNumber FOREIGN KEY([RoomNumberId]) REFERENCES RoomNumbers(RoomNumberId),
	CONSTRAINT FK_BookingUser FOREIGN KEY([UserId]) REFERENCES Users(UserId),
)
