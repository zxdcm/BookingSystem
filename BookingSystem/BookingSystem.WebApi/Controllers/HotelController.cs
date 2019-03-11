using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.HotelCommands.Commands;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Queries;
using BookingSystem.Queries.Queries.HotelQueries.Queries;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.Queries.Queries.RoomQueries.Queries;
using BookingSystem.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/hotel")]
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
        /// <param name="hotelRequestModel"></param>
        /// <remarks>
        /// Sample request:
        ///
        /// 
        /// </remarks>
        /// <returns>List of hotels views</returns>
        [HttpGet]
        public async Task<IActionResult> GetHotelsListAsync([FromQuery] HotelsRequestModel hotelRequestModel)
        {
            var query = hotelRequestModel.ToQuery();
            var queryResult =  await _queryDispatcher.DispatchAsync(query);
            return Ok(queryResult);
        }

        [HttpGet("{hotelId}/extraservices")]
        public async Task<IActionResult> GetHotelExtraServicesAsync(int hotelId)
        {
            var query = new ListExtraServicesQuery(hotelId);
            var queryResult = await _queryDispatcher.DispatchAsync(query);
            return Ok(queryResult);
        }

        [HttpGet("{hotelId}/rooms")]
        public async Task<IActionResult> GetHotelRoomsAsync(int hotelId)
        {
            var query = new ListRoomsQuery(hotelId);
            var queryResult = await _queryDispatcher.DispatchAsync(query);
            return Ok(queryResult);
        }

        // GET: api/Hotels/5
        /// <summary>
        /// Return hotel by specified id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelAsync(int hotelId)
        {
            var result = await _queryDispatcher.DispatchAsync(new HotelDetailsQuery(hotelId));
            if (result == null)
                return NotFound(hotelId);
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
        }

        // PUT: api/Hotels/5
        /// <summary>
        /// Edit a hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut("{hotelId}")]
        public async Task<IActionResult> EditHotelAsync(int hotelId, [FromBody] EditedHotelDto hotel)
        {
            if (hotelId != hotel.HotelId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new EditHotelCommand(hotel));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetHotelAsync), new { hotelId = result.Value }, null);
        }

        // DELETE: api/Hotel/5
        /// <summary>
        /// Deactive a hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> DeleteHotelAsync(int hotelId)
        {
            var result = await _commandDispatcher.DispatchAsync(new DeleteHotelCommand(hotelId));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return Ok();
        }
    }
}
