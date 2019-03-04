using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.Commands;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.HotelQueries;
using BookingSystem.Queries.Views;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    //Todo: rm project reference later
    //Todo: rm PropertyDescriptor
    //Todo: rm write context reference
    [Produces("application/json")]
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<HotelController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        
        public HotelController(IMapper mapper, 
            ILogger<HotelController> logger, 
            IQueryDispatcher queryDispatcher, 
            ICommandDispatcher commandDispatcher)
        {
            _mapper = mapper;
            _logger = logger;
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
        public async Task<IEnumerable<HotelView>> GetHotelsList([FromQuery] ListHotelsQuery query)
        {
            return await _queryDispatcher.Dispatch(query).ToArrayAsync();
//            var dto = new EditedHotelDto() { CityId = 1, Address = "10", CountryId = 1, IsActive = true, Name = "Name" };
//            var hotel = new Hotel(){HotelId = 2, ExtraServices = new List<ExtraService>{ new ExtraService(), new ExtraService()}};
//            _logger.LogDebug(hotel.ExtraServices.Count().ToString());
//            var (list, MappedEntity) = Test.Test.TestMapping(dto, hotel, _mapper, _logger);
//            _logger.LogDebug(MappedEntity.ExtraServices.Count().ToString());
//            return string.Join("\n", list);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Hotels/5
        /// <summary>
        /// Return hotel by specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
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
        /// <response code="404">If city not found</response>
        /// <responce code="201">New hotel created</responce>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddHotel([FromBody] NewHotelDto hotel)
        {
            _logger.LogDebug("Start add");
            var result = await _commandDispatcher.Dispatch(new AddHotelCommand(hotel));
            return FromResult(result);
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
            var result = await _commandDispatcher.Dispatch(new EditHotelCommand(hotel));
            return FromResult(result);
            //return result.IsSuccessful ? CreatedAtAction(nameof(GetHotel), new { id = result.Value }) : BadRequest(result.ErrorMessage);
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
            var result = await _commandDispatcher.Dispatch(new DeleteHotelCommand(id));
            return FromResult(result);
        }
    }
}
