using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Queries.Queries.CityQueries.Views
{
    public class CityView
    {
        public int CityId { get; set; }
        public string CityName{ get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
    }
}
