using System.Threading.Tasks;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Common.Utils;
using BookingSystem.Queries.Queries.BookingQueries.Queries;
using BookingSystem.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/booking")]
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

        // GET: api/Bookings/5
        [HttpGet("{bookingId}")]
        [Authorize(Roles = RoleName.Admin)]
        public async Task<IActionResult> GetBookingAsync(int bookingId)
        {
            var result = await _queryDispatcher.DispatchAsync(new BookingDetailsQuery(bookingId));
            if (result==null)
                return NotFound(bookingId);
            return Ok(result);
        }

        // POST: api/Bookings
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBookingAsync([FromBody] NewBookingDto booking)
        {
            var userId = User.GetUserId();
            var result = await _commandDispatcher.DispatchAsync(new BookRoomCommand(booking, userId));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetBookingAsync), new { bookingId = result.Value }, null);

        }

        // PUT: api/Bookings/5
        [HttpPut("{bookingId}")]
        [Authorize]
        [BookingPermissions]
        public async Task<IActionResult> CompleteBookingAsync(int bookingId, [FromBody] CompleteBookingDto booking)
        {
            if (bookingId != booking.BookingId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new CompleteBookingCommand(booking));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return Ok(bookingId);
        }
    }
}
