using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.BookingQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {

        private readonly ILogger<BookingController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public BookingController(ILogger<BookingController> logger,
            ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/Booking
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var result = await _queryDispatcher.Dispatch(new BookingDetailsQuery(id));
            if (result==null)
                return NotFound(id);
            return Ok(result);
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewBookingDto booking)
        {
            var result = await _commandDispatcher.Dispatch(new BookRoomCommand(booking));
            return FromResult(result);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompleteBookingDto booking)
        {
            var result = await _commandDispatcher.Dispatch(new CompleteBookingCommand(booking));
            return FromResult(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
