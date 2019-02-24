using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Image
    {
        public Image()
        {
            HotelImages = new HashSet<HotelImage>();
            RoomsImages = new HashSet<RoomsImage>();
        }

        public int ImageId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<HotelImage> HotelImages { get; set; }
        public virtual ICollection<RoomsImage> RoomsImages { get; set; }
    }
}
