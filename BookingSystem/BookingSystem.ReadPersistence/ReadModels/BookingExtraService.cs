using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class BookingExtraService
    {
        public int BookingId { get; set; }
        public int ExtraServiceId { get; set; }

        public Booking Booking { get; set; }
        public ExtraService ExtraService { get; set; }
    }
}
