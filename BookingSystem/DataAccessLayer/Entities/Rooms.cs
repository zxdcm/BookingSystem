using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Rooms
    {
        public Rooms()
        {
            RoomNumbers = new HashSet<RoomNumbers>();
            RoomsImages = new HashSet<RoomsImages>();
        }

        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }

        public virtual Hotels Hotel { get; set; }
        public virtual ICollection<RoomNumbers> RoomNumbers { get; set; }
        public virtual ICollection<RoomsImages> RoomsImages { get; set; }
    }
}
