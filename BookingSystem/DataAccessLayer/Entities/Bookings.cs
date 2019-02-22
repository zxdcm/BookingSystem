using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Bookings
    {
        public Bookings()
        {
            BookingExtraServices = new HashSet<BookingExtraServices>();
        }

        public int BookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public byte Status { get; set; }
        public int RoomNumberId { get; set; }
        public int UserId { get; set; }

        public virtual RoomNumbers RoomNumber { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<BookingExtraServices> BookingExtraServices { get; set; }
    }
}
