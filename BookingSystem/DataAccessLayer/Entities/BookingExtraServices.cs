using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class BookingExtraServices
    {
        public int BookingId { get; set; }
        public int ExtraServiceId { get; set; }

        public virtual Bookings Booking { get; set; }
        public virtual ExtraServices ExtraService { get; set; }
    }
}
