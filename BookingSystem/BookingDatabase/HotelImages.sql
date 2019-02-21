CREATE TABLE [dbo].[HotelImages]
(
	[HotelId] INT FOREIGN KEY REFERENCES [Hotels] ([HotelId]) NOT NULL,
	[ImageId] INT FOREIGN KEY REFERENCES [Images] ([ImageId]) NOT NULL,
	CONSTRAINT [PK_HotelImages] PRIMARY KEY ([HotelId], [ImageId]),
);
