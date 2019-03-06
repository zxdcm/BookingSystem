using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Hotel
    {
        public Hotel()
        {

        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

    }
}
