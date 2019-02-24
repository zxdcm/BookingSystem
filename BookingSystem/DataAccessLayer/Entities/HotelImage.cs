using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class HotelImage
    {
        public int HotelId { get; set; }
        public int ImageId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Image Image { get; set; }
    }
}
