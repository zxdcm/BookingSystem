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

            //1. This works fine but produces 2 queries
            //   One for hotel & countries & cities, another one - for services

            //            var hotelView =
            //                from hotel in _dataContext.Hotels
            //                join city in _dataContext.Cities
            //                    on hotel.CityId equals city.CityId
            //                join country in _dataContext.Countries
            //                    on hotel.CountryId equals country.CountryId
            //                where hotel.HotelId == query.HotelId
            //                select new HotelDetailsView()
            //                {
            //                    HotelId = hotel.HotelId,
            //                    Name = hotel.Name,
            //                    Address  = hotel.Address,
            //                    CountryName = country.Name,
            //                    CityName = city.Name,
            //                    IsActive = hotel.IsActive,
            //                    ExtraServices = from service in _dataContext.ExtraServices
            //                                    where service.HotelId == query.HotelId
            //                                    select new ExtraServiceView()
            //                                    {
            //                                        ExtraServiceId = service.ExtraServiceId,
            //                                        HotelId = service.HotelId,
            //                                        IsActive = service.IsActive,
            //                                        Name = service.Name,
            //                                        Price = service.Price,
            //                                    }
            //                };


            //sync methods -> works fine, produces 1 query. 
            //async methods -> exception throw.

            /*            var hotelViews =
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
                            select new HotelDetailsView
                            {
                                HotelId = gr.Key.HotelId,
                                Name = gr.Key.Name,
                                Address = gr.Key.Address,
                                CountryName = gr.Key.CountryName,
                                CityName = gr.Key.CityName,
                                IsActive = gr.Key.IsActive,
                                ExtraServices = gr.Select(s => new ExtraServiceView()
                                {
                                    ExtraServiceId = s.ExtraServiceId,
                                    HotelId = s.HotelId,
                                    IsActive = s.IsActive,
                                    Name = s.Name,
                                    Price = s.Price,
                                })
                            };*/

            // 1 query but have to fetch all ExtraServices info and select in-memory

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
