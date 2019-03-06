using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        private readonly ILogger<ValuesController> _logger;
        private readonly ICommandDispatcher _dispatcher;

        public ValuesController(ILogger<ValuesController> logger, ICommandDispatcher dispatcher)
        {
            Guard.Against.Null(logger, nameof(logger));
            Guard.Against.Null(dispatcher, nameof(dispatcher));
            _logger = logger;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            _logger.LogInformation("{0}", 10);
            var command = new BookRoomCommand(new NewBookingDto { UserId = 1, RoomId = 1 });
            _logger.LogInformation(_dispatcher == null ? "Null" : "Not null");
            var result = await _dispatcher.Dispatch(command);
            _logger.LogInformation("{0}{1}", result.IsSuccessful, result?.Value ?? "No value");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
