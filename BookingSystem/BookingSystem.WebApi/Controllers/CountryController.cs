using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public CountryController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryListAsync([FromQuery] CountryRequestModel countryRequest)
        {
            var query = countryRequest.ToQuery();
            var queryResult = await _queryDispatcher.DispatchAsync(query);
            return Ok(queryResult);
        }
    }
}
