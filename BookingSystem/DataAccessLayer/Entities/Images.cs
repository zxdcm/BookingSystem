using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Images
    {
        public Images()
        {
            HotelImages = new HashSet<HotelImages>();
            RoomsImages = new HashSet<RoomsImages>();
        }

        public int ImageId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<HotelImages> HotelImages { get; set; }
        public virtual ICollection<RoomsImages> RoomsImages { get; set; }
    }
}
