using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BookingSystem.ReadPersistence.ReadModels;

namespace BookingSystem.Queries.Views
{
    public class RoomView
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<int> RoomImagesIds { get; set; }

        public static Expression<Func<Room, RoomView>> Projection
            => room => new RoomView
            {
                RoomId = room.RoomId,
                Price = room.Price,
                Name = room.Name,
                HotelId = room.HotelId,
                Quantity = room.Quantity,
                Size = room.Size,
                RoomImagesIds = room.RoomsImages.AsQueryable().Select(image => image.ImageId),
            };
    }
}
