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
    public class ListCitiesQuery : IQuery<IEnumerable<CityView>>
    {
        public string CityNameLike { get; }
        public int CountryId { get; }
        public int Amount { get; }

        public ListCitiesQuery(string cityNameLike, int countryId, int amount)
        {
            CityNameLike = cityNameLike;
            CountryId = countryId;
            Amount = amount;
        }
    }

    public class ListCitiesQueryHandler : IQueryHandler<ListCitiesQuery, IEnumerable<CityView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListCitiesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CityView>> ExecuteAsync(ListCitiesQuery query)
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
                .WhereIf(query.CountryId != 0, 
                    city => city.CountryId == query.CountryId)
                .Take(query.Amount)
                .ToListAsync();
        }
    }
}
