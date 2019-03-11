using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.BookingQueries.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/bookings")]
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

        // GET: api/Bookings
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingAsync(int id)
        {
            var result = await _queryDispatcher.DispatchAsync(new BookingDetailsQuery(id));
            if (result==null)
                return NotFound(id);
            return Ok(result);
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> AddBookingAsync([FromBody] NewBookingDto booking)
        {
            var result = await _commandDispatcher.DispatchAsync(new BookRoomCommand(booking));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetBookingAsync), new { id = result.Value }, null);

        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> CompleteBookingAsync(int id, [FromBody] CompleteBookingDto booking)
        {
            if (id != booking.BookingId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new CompleteBookingCommand(booking));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetBookingAsync), new { id = result.Value }, null);
        }
    }
}
