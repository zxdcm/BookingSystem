using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.CountryQueries
{
    public class CountryDetailsQuery : IQuery<Task<CountryView>>
    {
        public int CountryId { get; }

        public CountryDetailsQuery(int countryId)
        {
            CountryId = countryId;
        }
    }

    public class CountryDetailsQueryHandler : IQueryHandler<CountryDetailsQuery, Task<CountryView>>
    {
        private readonly BookingReadContext _dataContext;

        public CountryDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CountryView> Execute(CountryDetailsQuery query)
        {
            return await _dataContext.Countries.Select(country => new CountryView()
            {
                CountryId = country.CountryId,
                CountryName = country.Name,
            }).FirstOrDefaultAsync(c => c.CountryId == query.CountryId);
        }
    }
}
