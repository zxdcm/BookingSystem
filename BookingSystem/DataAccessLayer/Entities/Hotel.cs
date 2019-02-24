using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
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

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<ExtraService> ExtraServices { get; set; }
        public virtual ICollection<HotelImage> HotelImages { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
