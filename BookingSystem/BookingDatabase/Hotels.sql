CREATE TABLE [dbo].[Hotels]
(
	[HotelId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	[IsActive] BIT DEFAULT 1 NOT NULL,
	[LocationId] INT NOT NULL,
	CONSTRAINT FK_HotelLocation FOREIGN KEY([LocationId]) REFERENCES Locations(LocationId)
)
