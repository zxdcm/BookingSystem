CREATE TABLE [dbo].[Hotels]
(
	[HotelId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(80) NOT NULL,
	[IsActive] BIT DEFAULT 1 NOT NULL,
	[Address] NVARCHAR(MAX) NOT NULL,
	[CountryId] INT NOT NULL,
	[CityId] INT NOT NULL,
	CONSTRAINT [FK_Hotel_Country] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([CountryId]),
	CONSTRAINT [FK_Hotel_City] FOREIGN KEY ([CityId]) REFERENCES [Cities]([CityId]),
	CONSTRAINT [PK_Hotel] PRIMARY KEY ([HotelId]),
)
