﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.BookingQueries.Queries;
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
            var result = await _queryDispatcher.DispatchAsync(new BookingDetailsQuery(id));
            if (result==null)
                return NotFound(id);
            return Ok(result);
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] NewBookingDto booking)
        {
            var result = await _commandDispatcher.DispatchAsync(new BookRoomCommand(booking));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, null);

        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> CompleteBooking(int id, [FromBody] CompleteBookingDto booking)
        {
            var result = await _commandDispatcher.DispatchAsync(new CompleteBookingCommand(booking));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, null);
        }
    }
}
