CREATE TABLE [dbo].[BookingExtraServices]
(
	[BookingId] INT NOT NULL,
	[ExtraServiceId] INT NOT NULL,
	CONSTRAINT PK_BookingExtraServices PRIMARY KEY ([BookingId], [ExtraServiceId]),
)
