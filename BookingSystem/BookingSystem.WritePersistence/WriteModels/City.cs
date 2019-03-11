using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
