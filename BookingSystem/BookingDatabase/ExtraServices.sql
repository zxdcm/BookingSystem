CREATE TABLE [dbo].[ExtraServices]
(
	[ExtraServiceId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	[Price] DECIMAL(18, 4) NOT NULL,
	[HotelId] INT NOT NULL,
	CONSTRAINT FK_ExtraServiceHotel FOREIGN KEY([HotelId]) REFERENCES Hotels(HotelId),
)
