using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.ApplicationCore.Entities.ReadModels
{
    public partial class Room
    {
        private ICollection<RoomNumber> _roomNumbers;
        private ICollection<RoomsImage> _roomsImages;

        public Room()
        {
            _roomNumbers = new HashSet<RoomNumber>();
            _roomsImages = new HashSet<RoomsImage>();
        }

        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual IReadOnlyCollection<RoomNumber> RoomNumbers => _roomNumbers.ToList();

        public virtual IReadOnlyCollection<RoomsImage> RoomsImages => _roomsImages.ToList();


    }
}
