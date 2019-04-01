using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Queries.Queries.CityQueries.Queries;

namespace BookingSystem.WebApi.Models
{
    public class CityRequestModel
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int Amount { get; set; }

        public ListCitiesQuery ToQuery()
            => new ListCitiesQuery(CityName, CountryId, Amount);
    }
}
