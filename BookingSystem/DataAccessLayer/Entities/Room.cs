using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Room
    {
        public Room()
        {
            RoomNumbers = new HashSet<RoomNumber>();
            RoomsImages = new HashSet<RoomsImage>();
        }

        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<RoomNumber> RoomNumbers { get; set; }
        public virtual ICollection<RoomsImage> RoomsImages { get; set; }
    }
}
