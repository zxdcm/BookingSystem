CREATE TABLE [dbo].[BookingExtraServices]
(
	[BookingId] INT FOREIGN KEY REFERENCES [Bookings] ([BookingId]) NOT NULL,
	[ExtraServiceId] INT FOREIGN KEY REFERENCES [ExtraServices] ([ExtraServiceId]) NOT NULL,
	CONSTRAINT [PK_BookingExtraServices] PRIMARY KEY ([BookingId], [ExtraServiceId]),
)
