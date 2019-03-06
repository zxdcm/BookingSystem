using System;
using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            RoomsImages = new HashSet<RoomsImage>();
        }

        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public int Quantity { get; set; }

        public Hotel Hotel { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<RoomsImage> RoomsImages { get; set; }
    }
}
