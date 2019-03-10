using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.BookingCommands.Commands;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Commands.Commands.ExtraServiceCommands.Commands;
using BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/extraservices")] //TODO: fix later
    [ApiController]
    public class ExtraServiceController : ControllerBase
    {
        private readonly ILogger<ExtraServiceController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ExtraServiceController(ILogger<ExtraServiceController> logger,
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/extraservices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExtraServiceAsync(int id)
        {
            var result = await _queryDispatcher.DispatchAsync(new ExtraServiceDetailsQuery(id));
            if (result == null)
                return NotFound(id);
            return Ok(result);
        }

        // GET: api/extraservices/
        [HttpGet]
        public async Task<IActionResult> GetExtraServicesAsync([FromQuery] ListExtraServicesQuery query)
        {
            var result = await _queryDispatcher.DispatchAsync(query);
            return Ok(result);
        }

        // POST: api/extraservices
        [HttpPost]
        public async Task<IActionResult> AddExtraServiceAsync([FromBody] NewExtraServiceDto extraService)
        {
            var result = await _commandDispatcher.DispatchAsync(new AddExtraServiceCommand(extraService));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetExtraServiceAsync), new { id = result.Value }, null);

        }

        // PUT: api/extraservices/
        [HttpPut("{id}")]
        public async Task<IActionResult> EditExtraServiceAsync(int id, [FromBody] EditedExtraServiceDto extraService)
        {
            if (id != extraService.ExtraServiceId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new EditExtraServiceCommand(extraService));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetExtraServiceAsync), new { id = result.Value }, null);
        }
    }
}