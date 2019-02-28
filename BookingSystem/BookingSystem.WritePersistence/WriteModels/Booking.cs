using System;
using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class Booking
    {
        public Booking()
        {
            BookingExtraServices = new HashSet<BookingExtraService>();
        }

        public int BookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public byte Status { get; set; }
        public int RoomNumberId { get; set; }
        public int UserId { get; set; }

        public virtual RoomNumber RoomNumber { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingExtraService> BookingExtraServices { get; set; }
    }
}
