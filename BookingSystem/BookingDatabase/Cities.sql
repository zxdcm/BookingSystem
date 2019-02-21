﻿CREATE TABLE [dbo].[Cities]
(
	[CityId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	[CountryId] INT NOT NULL,
	CONSTRAINT [FK_City_Country] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([CountryId]),
)