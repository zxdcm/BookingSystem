CREATE TABLE [dbo].[BookingExtraServices]
(
	[BookingId] INT NOT NULL,
	[ExtraServiceId] INT NOT NULL,
	CONSTRAINT [FK_BookingExtraService_Booking] FOREIGN KEY([BookingId]) REFERENCES [Bookings] ([BookingId]),
	CONSTRAINT [FK_BookingExtraService_ExtraService] FOREIGN KEY([ExtraServiceId]) REFERENCES [ExtraServices] ([ExtraServiceId]),
	CONSTRAINT [PK_BookingExtraService] PRIMARY KEY ([BookingId], [ExtraServiceId]),
)
