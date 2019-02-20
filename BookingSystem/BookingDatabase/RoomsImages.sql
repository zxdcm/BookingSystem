﻿CREATE TABLE [dbo].[RoomsImages]
(
	[RoomId] INT FOREIGN KEY REFERENCES Rooms(RoomId) NOT NULL,
	[ImageId] INT FOREIGN KEY REFERENCES Images(ImageID),
	CONSTRAINT PK_RoomImages PRIMARY KEY ([RoomId], [ImageId]),
)
