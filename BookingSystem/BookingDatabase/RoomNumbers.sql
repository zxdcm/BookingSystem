﻿CREATE TABLE [dbo].[RoomNumbers]
(
	[RoomNumberId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[IsAvailable] BIT DEFAULT 1 NOT NULL,
	[Number] INT NOT NULL,
	[RoomId] INT NOT NULL,
	CONSTRAINT [FK_RoomNumber_Number] FOREIGN KEY([RoomId]) REFERENCES Rooms([RoomId]),
)
