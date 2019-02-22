using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class HotelImages
    {
        public int HotelId { get; set; }
        public int ImageId { get; set; }

        public virtual Hotels Hotel { get; set; }
        public virtual Images Image { get; set; }
    }
}
