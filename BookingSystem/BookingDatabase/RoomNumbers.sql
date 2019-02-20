CREATE TABLE [dbo].[RoomNumbers]
(
	[RoomNumberId] INT NOT NULL PRIMARY KEY,
	[IsAvailable] BIT DEFAULT 1 NOT NULL,
	[Number] INT NOT NULL,
	[RoomId] INT NOT NULL,
	CONSTRAINT FK_NumberRoom FOREIGN KEY([RoomId]) REFERENCES Rooms(RoomId),
)
