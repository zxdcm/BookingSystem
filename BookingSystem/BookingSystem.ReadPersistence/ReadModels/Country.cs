using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Country
    {
        public Country() { }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
