using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.CityQueries
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
            return await _dataContext.Cities.Select(city => new CityView()
            {
                CityId = city.CityId,
                CountryId = city.CountryId,
                CityName = city.Name,
                CountryName = city.Country.Name,
            }).FirstOrDefaultAsync(c => c.CityId == query.CityId);
        }
    }
}
