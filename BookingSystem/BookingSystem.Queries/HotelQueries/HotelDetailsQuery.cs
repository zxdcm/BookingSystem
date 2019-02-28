using System.Linq;
using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Views;
using BookingSystem.Common.Interfaces;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.HotelQueries
{
    public class HotelDetailsQuery : IQuery<Task<HotelView>>
    {
        public int HotelId { get; }
         
        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }

        internal sealed class HotelDetailsQueryHandler : IQueryHandler<HotelDetailsQuery, Task<HotelView>>
        {
            private readonly BookingReadContext _dataContext;

            public HotelDetailsQueryHandler(BookingReadContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Task<HotelView> Execute(HotelDetailsQuery query)
            {
                return _dataContext.Hotels
                    .Select(hotel => new HotelView
                    {
                        HotelId = hotel.HotelId,
                        Address = hotel.Address,
                        IsActive = hotel.IsActive.Value, //TODO: ask
                    CountryName = hotel.Country.Name,
                        CityName = hotel.Country.Name,
                    })
                    .FirstOrDefaultAsync(hotel => hotel.HotelId == query.HotelId);
            }
        }
    }
}
