CREATE TABLE [dbo].[ExtraServices]
(
	[ExtraServiceId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(80) NOT NULL,
	[Price] DECIMAL(18, 4) NOT NULL,
	[IsActive] BIT DEFAULT 1 NOT NULL,
	[HotelId] INT NOT NULL,
	CONSTRAINT [FK_ExtraService_Hotel] FOREIGN KEY([HotelId]) REFERENCES [Hotels] ([HotelId]),
	CONSTRAINT [PK_ExtraService] PRIMARY KEY ([ExtraServiceId]),
)
