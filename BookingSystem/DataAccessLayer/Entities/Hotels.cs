using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Hotels
    {
        public Hotels()
        {
            ExtraServices = new HashSet<ExtraServices>();
            HotelImages = new HashSet<HotelImages>();
            Rooms = new HashSet<Rooms>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Countries Country { get; set; }
        public virtual ICollection<ExtraServices> ExtraServices { get; set; }
        public virtual ICollection<HotelImages> HotelImages { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
