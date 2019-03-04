using System;
using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class ExtraService
    {
        public ExtraService()
        {
            BookingExtraServices = new HashSet<BookingExtraService>();
        }

        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        public ICollection<BookingExtraService> BookingExtraServices { get; set; }
    }
}
