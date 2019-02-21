CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CreatedDate] DATETIME2 NOT NULL,
	[MoveInDate] DATETIME2 NOT NULL,
	[MoveOutDate] DATETIME2 NOT NULL,
	[TotalPrice] DECIMAL(18, 4),
	[Status] TINYINT NOT NULL,
	[RoomNumberId] INT NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_Booking_RoomNumber] FOREIGN KEY([RoomNumberId]) REFERENCES RoomNumbers([RoomNumberId]),
	CONSTRAINT [FK_Booking_User] FOREIGN KEY([UserId]) REFERENCES Users([UserId]),
)
