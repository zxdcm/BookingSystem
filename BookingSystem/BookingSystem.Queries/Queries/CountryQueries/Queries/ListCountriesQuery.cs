using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.Queries.Queries.CityQueries.Queries;
using BookingSystem.Queries.Queries.CityQueries.Views;
using BookingSystem.Queries.Queries.CountryQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.CountryQueries.Queries
{
    public class ListCountriesQuery : IQuery<IEnumerable<CountryView>>
    {
        public string CountryNameLike { get; }
        public int Amount { get; }

        public ListCountriesQuery(string countryNameLike, int amount)
        {
            CountryNameLike = countryNameLike;
            Amount = amount;
        }
    }


    public class ListCountriesQueryHandler : IQueryHandler<ListCountriesQuery, IEnumerable<CountryView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListCountriesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CountryView>> ExecuteAsync(ListCountriesQuery query)
        {
            return await _dataContext.Countries
                .WhereIf(!string.IsNullOrWhiteSpace(query.CountryNameLike),
                    country => country.Name.StartsWith(query.CountryNameLike))
                .Select(country => new CountryView()
                {
                    CountryId = country.CountryId,
                    CountryName = country.Name
                })
                .Take(query.Amount)
                .ToListAsync();
        }
    }
}
