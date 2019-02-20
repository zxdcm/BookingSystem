CREATE TABLE [dbo].[Locations]
(
	[LocationId] INT NOT NULL PRIMARY KEY,
	[Address] NVARCHAR(max) NOT NULL,
	[CityId] INT NOT NULL,
	CONSTRAINT FK_LocationCity FOREIGN KEY([CityId]) REFERENCES Cities(CityId),
)
