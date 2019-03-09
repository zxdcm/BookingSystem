using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.HotelCommands.Commands;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.HotelQueries.Queries;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        
        public HotelController(
            IQueryDispatcher queryDispatcher, 
            ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        // GET: api/Hotels
        /// <summary>
        /// Return hotels list by incoming query
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>
        /// Sample request:
        ///
        /// 
        /// </remarks>
        /// <returns>List of hotels views</returns>
        [HttpGet]
        public async Task<IEnumerable<HotelPreView>> GetHotelsListAsync([FromQuery] ListHotelsQuery query)
        {
            return await _queryDispatcher.Dispatch(query).ToArrayAsync();
        }

        // GET: api/Hotels/5
        /// <summary>
        /// Return hotel by specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelAsync(int id)
        {
            var result = await _queryDispatcher.Dispatch(new HotelDetailsQuery(id));
            if (result == null)
                return NotFound(id);
            return Ok(result);
        }

        // POST: api/Hotels
        /// <summary>
        /// Creates a hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        /// <response code="422">If city not found</response>
        /// <responce code="201">New hotel created</responce>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddHotelAsync([FromBody] NewHotelDto hotel)
        {
            var result = await _commandDispatcher.DispatchAsync(new AddHotelCommand(hotel));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetHotelAsync), new {id = result.Value}, null);
//            return FromResult(result);
        }

        // PUT: api/Hotels/5
        /// <summary>
        /// Edit a hotel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditHotel(int id, [FromBody] EditedHotelDto hotel)
        {
            //Todo: ask
            if (id != hotel.HotelId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new EditHotelCommand(hotel));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetHotelAsync), new { id = result.Value }, null);
        }

        // DELETE: api/Hotel/5
        /// <summary>
        /// Deactive a hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _commandDispatcher.DispatchAsync(new DeleteHotelCommand(id));
            return FromResult(result);
        }
    }
}
