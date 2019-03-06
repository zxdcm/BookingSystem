using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.Queries.Queries.RoomQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.HotelQueries.Queries
{
    public class HotelDetailsQuery : IQuery<Task<HotelDetailsView>>
    {
        public int HotelId { get; }

        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class HotelDetailsQueryHandler : IQueryHandler<HotelDetailsQuery, Task<HotelDetailsView>>
    {
        private readonly BookingReadContext _dataContext;

        public HotelDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HotelDetailsView> Execute(HotelDetailsQuery query)
        {

            var hotels =
                from hotel in _dataContext.Hotels
                join city in _dataContext.Cities
                    on hotel.CityId equals city.CityId
                join country in _dataContext.Countries
                    on hotel.CountryId equals country.CountryId
                join service in _dataContext.ExtraServices
                    on hotel.HotelId equals service.HotelId into services
                from service in services.DefaultIfEmpty()
                select new HotelDetailsView()
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address  = hotel.Address,
                    CountryName = country.Name,
                    CityName = city.Name,
                    IsActive = hotel.IsActive,
//                    ExtraServices = service.Select(se => new ExtraServiceView()
//                    {
//                        HotelId = se.HotelId,
//                        Name = se.Name,
//                        IsAvailable = se.IsAvailable,
//                        ExtraServiceId = se.ExtraServiceId,
//                        Price = se.Price
//                    }),
                };
            return await hotels
                .FirstOrDefaultAsync(h => h.HotelId == query.HotelId);
        }
    }
}

/*            var queryRaw =
                from hotel in hotels
                join city in cities
                on city.CityId equals hotel.CityId
                join country in countries 
                on country.CountryId equals city.CountryId
                select new
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = country.Name,
                    CityName = city.Name,
                    IsActive = hotel.IsActive,
                };*/

/*

            on city.CityId == hotel.CityId
            return _dataContext.Hotels
                .Select(hotel => new HotelView
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = hotel.Country.Name,
                    CityName = hotel.City.Name,
                    IsActive = hotel.IsActive,
                    HotelImagesIds = _dataContext.HotelImages.Select(image => image.ImageId),
                    ExtraServices = _dataContext.ExtraServices.Select(service => new ExtraServiceView()
                    {
                        ExtraServiceId = service.ExtraServiceId,
                        HotelId = service.HotelId,
                        IsAvailable = service.IsAvailable,
                        Name = service.Name,
                        Price = service.Price
                    }),
                    Rooms = _dataContext.Rooms.Select(room => new RoomView()
                    {
                        RoomId = room.RoomId,
                        Price = room.Price,
                        Name = room.Name,
                        HotelId = room.HotelId,
                        Quantity = room.Quantity,
                        Size = room.Size,
                        RoomImagesIds = _dataContext.RoomsImages.Select(image => image.ImageId),
                    }), 
                })
                .FirstOrDefaultAsync(hotel => hotel.HotelId == query.HotelId);*/
