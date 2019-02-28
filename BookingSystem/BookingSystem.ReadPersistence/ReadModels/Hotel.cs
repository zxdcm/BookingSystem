using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Hotel
    {
        public Hotel()
        {
            _extraServices = new HashSet<ExtraService>();
            _hotelImages = new HashSet<HotelImage>();
            _rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }

        private ICollection<ExtraService> _extraServices;
        public virtual IReadOnlyCollection<ExtraService> ExtraServices => _extraServices.ToList();

        private ICollection<HotelImage> _hotelImages;
        public virtual IReadOnlyCollection<HotelImage> HotelImages => _hotelImages.ToList();

        private ICollection<Room> _rooms;
        public virtual IReadOnlyCollection<Room> Rooms => _rooms.ToList();

        public void AddExtraService(ExtraService extraService)
        {
            _extraServices.Add(extraService);
        }

        public void AddExtraServices(ICollection<ExtraService> extraServices)
        {
            foreach (var service in extraServices)
                _extraServices.Add(service);
        }


        public void UpdateExtraServices()
        { 
            throw new NotImplementedException();
        }
    }
}
