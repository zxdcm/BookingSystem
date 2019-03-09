using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.Queries.Queries.CityQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.CityQueries.Queries
{
    public class ListCitiesQuery : IQuery<Task<IEnumerable<CityView>>>
    {
        public string CityNameLike { get; }
        public string CountryNameLike { get; }
        public int Amount { get; }

        public ListCitiesQuery(string cityNameLike, string countryNameLike, int amount)
        {
            CityNameLike = cityNameLike;
            CountryNameLike = countryNameLike;
            Amount = amount;
        }
    }

    public class ListCitiesQueryHandler : IQueryHandler<ListCitiesQuery, Task<IEnumerable<CityView>>>
    {
        private readonly BookingReadContext _dataContext;

        public ListCitiesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CityView>> Execute(ListCitiesQuery query)
        {
            return await _dataContext.Cities
                .Select(city => new CityView()
                {
                    CityId = city.CityId,
                    CityName = city.Name,
                    CountryId = city.CountryId,
                })
                .WhereIf(!string.IsNullOrWhiteSpace(query.CityNameLike), 
                    city => city.CityName.StartsWith(query.CityNameLike))
                .WhereIf(!string.IsNullOrWhiteSpace(query.CountryNameLike), 
                    city => city.CountryName.StartsWith(query.CountryNameLike))
                .ToListAsync();
        }
    }
}
