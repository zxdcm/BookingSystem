﻿namespace BookingSystem.ApplicationCore.Entities.ReadModels
{
    public partial class RoomsImage
    {
        public int RoomId { get; set; }
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Room Room { get; set; }
    }
}
