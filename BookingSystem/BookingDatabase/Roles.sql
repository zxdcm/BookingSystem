﻿CREATE TABLE [dbo].[Roles]
(
	[RoleId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(80) NOT NULL,
	CONSTRAINT [PK_Role] PRIMARY KEY ([RoleId]),
)