using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class Hotel
    {
        public Hotel()
        {
            ExtraServices = new HashSet<ExtraService>();
            HotelImages = new HashSet<HotelImage>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public ICollection<ExtraService> ExtraServices { get; set; }
        public ICollection<HotelImage> HotelImages { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
