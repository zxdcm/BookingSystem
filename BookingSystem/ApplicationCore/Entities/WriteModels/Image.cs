using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.ApplicationCore.Entities.WriteModels
{
    public partial class Image
    {
        private ICollection<HotelImage> _hotelImages;
        private ICollection<RoomsImage> _roomsImages;

        public Image()
        {
            _hotelImages = new HashSet<HotelImage>();
            _roomsImages = new HashSet<RoomsImage>();
        }

        public int ImageId { get; set; }
        public string Url { get; set; }

        public virtual IReadOnlyCollection<HotelImage> HotelImages => _hotelImages.ToList();

        public virtual IReadOnlyCollection<RoomsImage> RoomsImages => _roomsImages.ToList();
    }
}
