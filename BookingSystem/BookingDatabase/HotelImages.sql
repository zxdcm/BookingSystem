CREATE TABLE [dbo].[HotelImages]
(
	[HotelId] INT NOT NULL,
	[ImageId] INT NOT NULL,
	CONSTRAINT [FK_HotelImage_Hotel] FOREIGN KEY ([HotelId]) REFERENCES Hotels([HotelId]),
	CONSTRAINT [FK_HotelImage_Image] FOREIGN KEY ([ImageId]) REFERENCES Images([ImageID]),
	CONSTRAINT [PK_HotelImage] PRIMARY KEY ([HotelId], [ImageId]),
);
