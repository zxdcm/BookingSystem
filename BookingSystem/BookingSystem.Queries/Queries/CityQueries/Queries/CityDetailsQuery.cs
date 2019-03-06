using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.CityQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.CityQueries.Queries
{
    public class CityDetailsQuery : IQuery<Task<CityView>>
    {
        public int CityId { get; }

        public CityDetailsQuery(int cityId)
        {
            CityId = cityId;
        }
    }

    public class CityDetailsQueryHandler : IQueryHandler<CityDetailsQuery, Task<CityView>>
    {
        private readonly BookingReadContext _dataContext;

        public CityDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CityView> Execute(CityDetailsQuery query)
        {
            var cities = from city in _dataContext.Cities
                         join country in _dataContext.Countries 
                             on city.CountryId equals country.CountryId
                         select new CityView()
                         {
                             CityId = city.CityId,
                             CountryId = city.CountryId,
                             CityName = city.Name,
                             CountryName = country.Name,
                         };
            return await cities.FirstOrDefaultAsync(c => c.CityId == query.CityId);

        }
    }
}
