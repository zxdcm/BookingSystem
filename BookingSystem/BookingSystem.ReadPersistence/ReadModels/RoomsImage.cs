﻿using System;
using System.Collections.Generic;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class RoomsImage
    {
        public int RoomId { get; set; }
        public int ImageId { get; set; }

        public Image Image { get; set; }
        public Room Room { get; set; }
    }
}