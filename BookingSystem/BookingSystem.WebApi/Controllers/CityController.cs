using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public CityController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCityListAsync([FromQuery] CityRequestModel cityRequest)
        {
            var query = cityRequest.ToQuery();
            var queryResult = await _queryDispatcher.DispatchAsync(query);
            return Ok(queryResult);
        }
    }
}