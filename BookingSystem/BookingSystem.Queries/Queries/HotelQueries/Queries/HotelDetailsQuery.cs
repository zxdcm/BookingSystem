using System;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.HotelQueries.Queries
{
    public class HotelDetailsQuery : IQuery<HotelDetailsView>
    {
        public int HotelId { get; }

        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class HotelDetailsQueryHandler : IQueryHandler<HotelDetailsQuery, HotelDetailsView>
    {
        private readonly BookingReadContext _dataContext;

        public HotelDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HotelDetailsView> ExecuteAsync(HotelDetailsQuery query)
        {
            var hotelViews =
                from hotel in _dataContext.Hotels
                join city in _dataContext.Cities
                    on hotel.CityId equals city.CityId
                join country in _dataContext.Countries
                    on hotel.CountryId equals country.CountryId
                where hotel.HotelId == query.HotelId
                join service in _dataContext.ExtraServices
                    on hotel.HotelId equals service.HotelId into services
                from service in services.DefaultIfEmpty()
                group service by new
                {
                    hotel.HotelId,
                    hotel.Name,
                    hotel.Address,
                    CountryName = country.Name,
                    CityName = city.Name,
                    hotel.IsActive,
                }
                into gr
                select gr;
            var hotelGr = await hotelViews.FirstOrDefaultAsync();
            if (hotelGr == null)
                return null;
            return new HotelDetailsView
            {
                HotelId = hotelGr.Key.HotelId,
                Name = hotelGr.Key.Name,
                Address = hotelGr.Key.Address,
                CountryName = hotelGr.Key.CountryName,
                CityName = hotelGr.Key.CityName,
                IsActive = hotelGr.Key.IsActive,
                ExtraServices = hotelGr.Select(s => new ExtraServiceView()
                {
                    ExtraServiceId = s.ExtraServiceId,
                    HotelId = s.HotelId,
                    IsActive = s.IsActive,
                    Name = s.Name,
                    Price = s.Price,
                })
            };
        }
    }
}
