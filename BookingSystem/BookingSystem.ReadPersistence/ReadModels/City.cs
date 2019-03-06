using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class City
    {
        public City()
        {

        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
