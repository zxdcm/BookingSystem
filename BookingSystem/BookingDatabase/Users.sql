﻿CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY(1,1) NOT NULL,
	[FirstName] NVARCHAR(80) NOT NULL,
	[SecondName] NVARCHAR(80) NOT NULL,
	[Email] NVARCHAR(80) NOT NULL,
	[PasswordHash] NVARCHAR(MAX) NOT NULL,
	[PasswordSalt] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY ([UserId]),
)
