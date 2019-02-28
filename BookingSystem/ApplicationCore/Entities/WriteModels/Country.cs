﻿using System.Collections.Generic;

namespace BookingSystem.ApplicationCore.Entities.WriteModels
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

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
