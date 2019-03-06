using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Image
    {
        public Image() { }

        public int ImageId { get; set; }
        public string Url { get; set; }
        
    }
}
