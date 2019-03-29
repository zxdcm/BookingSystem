using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Queries.Queries.CountryQueries.Queries;

namespace BookingSystem.WebApi.Models
{
    public class CountryRequestModel
    {
        public string CountryName { get; set; }
        public int Amount { get; set; }
        public ListCountriesQuery ToQuery() 
            => new ListCountriesQuery(CountryName, Amount);
    }
}
