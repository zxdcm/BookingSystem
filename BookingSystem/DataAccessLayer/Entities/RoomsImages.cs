using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class RoomsImages
    {
        public int RoomId { get; set; }
        public int ImageId { get; set; }

        public virtual Images Image { get; set; }
        public virtual Rooms Room { get; set; }
    }
}
