CREATE TABLE [dbo].[Rooms]
(
	[RoomId] INT IDENTITY(1,1) NOT NULL,
	[Price] DECIMAL(18, 4) NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Size] INT NOT NULL,
	[HotelId] INT NOT NULL, 
	[Quantity] INT NOT NULL,
	CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelId]) REFERENCES [Hotels] ([HotelId]),
	CONSTRAINT [PK_Room] PRIMARY KEY ([RoomId]),
)
