using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
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

        public ICollection<HotelImage> HotelImages { get; set; }
        public ICollection<RoomsImage> RoomsImages { get; set; }
    }
}
