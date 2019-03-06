using System;
using System.Collections.Generic;
using System.Text;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;

namespace BookingSystem.Queries.Queries.HotelQueries.Views
{
    public class HotelDetailsView
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<ExtraServiceView> ExtraServices { get; set; }
    }
}
