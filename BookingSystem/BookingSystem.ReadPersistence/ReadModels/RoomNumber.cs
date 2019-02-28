using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class RoomNumber
    {
        public RoomNumber()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomNumberId { get; set; }
        public bool? IsAvailable { get; set; }
        public int Number { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
