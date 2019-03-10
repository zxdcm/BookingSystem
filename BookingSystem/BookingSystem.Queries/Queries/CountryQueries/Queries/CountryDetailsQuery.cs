using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.CountryQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.CountryQueries.Queries
{
    public class CountryDetailsQuery : IQuery<CountryView>
    {
        public int CountryId { get; }

        public CountryDetailsQuery(int countryId)
        {
            CountryId = countryId;
        }
    }

    public class CountryDetailsQueryHandler : IQueryHandler<CountryDetailsQuery, CountryView>
    {
        private readonly BookingReadContext _dataContext;

        public CountryDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CountryView> ExecuteAsync(CountryDetailsQuery query)
        {
            var countries = from country in _dataContext.Countries
                select new CountryView()
                {
                    CountryId = country.CountryId,
                    CountryName = country.Name,
                };
            return await countries
                .FirstOrDefaultAsync(c => c.CountryId == query.CountryId);
        }
    }
}
