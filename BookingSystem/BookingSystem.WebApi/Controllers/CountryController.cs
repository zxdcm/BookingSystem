using System;
using System.Threading.Tasks;
using Autofac;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.Queries.Queries.HotelQueries.Queries;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IContainer _container;
        public CountryController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryListAsync([FromQuery] CountryRequestModel countryRequest)
        {
            var query = countryRequest.ToQuery();
            var queryResult = await _queryDispatcher.DispatchAsync(query);
//            var queryFork = new ListHotelsQuery("t", DateTime.Now, DateTime.Now, true, 1, 1,1);
//
//            var queryResult = await _queryDispatcher.DispatchAsync(new PagedQuery<ListHotelsQuery, HotelPreView>(){ Query = queryFork, PageInfo = new PageInfo()});

            return Ok(queryResult);
        }
    }
}
