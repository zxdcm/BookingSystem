CREATE TABLE [dbo].[Countries]
(
	[CountryId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(80) NOT NULL,
	CONSTRAINT [PK_Country] PRIMARY KEY ([CountryId])
)
