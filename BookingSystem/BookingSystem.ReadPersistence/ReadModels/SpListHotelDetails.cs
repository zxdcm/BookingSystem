using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public class SpListHotelDetails
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}
