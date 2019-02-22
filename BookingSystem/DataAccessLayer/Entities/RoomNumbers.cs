using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class RoomNumbers
    {
        public RoomNumbers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int RoomNumberId { get; set; }
        public bool? IsAvailable { get; set; }
        public int Number { get; set; }
        public int RoomId { get; set; }

        public virtual Rooms Room { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
