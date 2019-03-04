using System;
using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Hotels = new HashSet<Hotel>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
