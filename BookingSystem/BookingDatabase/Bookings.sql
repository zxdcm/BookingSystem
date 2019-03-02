CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT IDENTITY(1,1) NOT NULL,
	[CreatedDate] DATETIME2 NOT NULL,
	[MoveInDate] DATETIME2 NOT NULL,
	[MoveOutDate] DATETIME2 NOT NULL,
	[TotalPrice] DECIMAL(18, 4),
	[Status] TINYINT NOT NULL,
	[RoomId] INT NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_Booking_Room] FOREIGN KEY([RoomId]) REFERENCES [Rooms] ([RoomId]),
	CONSTRAINT [FK_Booking_User] FOREIGN KEY([UserId]) REFERENCES [Users] ([UserId]),
	CONSTRAINT [PK_Booking] PRIMARY KEY ([BookingId]),	
)
