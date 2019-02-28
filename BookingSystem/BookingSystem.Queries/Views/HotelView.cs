using System;
using System.Linq.Expressions;

namespace BookingSystem.ApplicationCore.Views
{
    public class HotelView
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
