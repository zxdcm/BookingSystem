using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookingSystem.ReadPersistence.ReadModels;

namespace BookingSystem.Queries.Views
{
    public class HotelView
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<int> HotelImagesIds { get; set; }
        public IEnumerable<ExtraServiceView> ExtraServices { get; set; }
        public IEnumerable<RoomView> Rooms { get; set; }
        //public string ImageUrl { get; set; }

        public static Expression<Func<Hotel, HotelView>> PartialProjection
            => hotel => new HotelView
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CountryName = hotel.Country.Name, //TODO: ask
                CityName = hotel.City.Name, 
                IsActive = hotel.IsActive,
                HotelImagesIds = hotel.HotelImages.AsQueryable().Select(image => image.ImageId),
            };

        public static Expression<Func<Hotel, HotelView>> FullProjection
            => hotel => new HotelView
            {
                HotelId = hotel.HotelId,
                Address = hotel.Address,
                CountryName = hotel.City.Country.Name,
                CityName = hotel.City.Name,
                IsActive = hotel.IsActive,
                HotelImagesIds = hotel.HotelImages.AsQueryable().Select(image => image.ImageId),
                ExtraServices = hotel.ExtraServices.AsQueryable().Select(ExtraServiceView.Projection),
                Rooms = hotel.Rooms.AsQueryable().Select(RoomView.Projection),
            };
    }
}
