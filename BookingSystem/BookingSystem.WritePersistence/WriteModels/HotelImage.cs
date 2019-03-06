using System;
using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class HotelImage
    {
        public int HotelId { get; set; }
        public int ImageId { get; set; }

        public Hotel Hotel { get; set; }
        public Image Image { get; set; }
    }
}
