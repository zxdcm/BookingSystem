CREATE TABLE [dbo].[RoomsImages]
(
	[RoomId] INT NOT NULL,
	[ImageId] INT NOT NULL,
	CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([RoomId]),
	CONSTRAINT [FK_RoomImage_Image] FOREIGN KEY ([ImageId]) REFERENCES [Images] ([ImageId]),
	CONSTRAINT [PK_RoomImage] PRIMARY KEY ([RoomId], [ImageId]),
)
