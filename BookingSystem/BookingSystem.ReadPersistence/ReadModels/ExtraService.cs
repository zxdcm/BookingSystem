using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class ExtraService
    {
        public ExtraService()
        {

        }

        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
        public int HotelId { get; set; }
    }
}
