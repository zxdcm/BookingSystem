using System.Threading.Tasks;
using BookingSystem.Commands.Commands.RoomCommands.Commands;
using BookingSystem.Commands.Commands.RoomCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Common.Utils;
using BookingSystem.Queries.Queries.RoomQueries.Queries;
using BookingSystem.ReadPersistence.ReadModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/room")]
    [Authorize(Roles = RoleName.Admin)]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public RoomController(ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{roomId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoomAsync(int roomId)
        {
            var query = new RoomDetailsQuery(roomId);
            var queryResult = await _queryDispatcher.DispatchAsync(query);
            if (queryResult == null)
                return NotFound(roomId);
            return Ok(queryResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomAsync([FromBody] NewRoomDto room)
        {
            var result = await _commandDispatcher.DispatchAsync(new AddRoomCommand(room));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetRoomAsync), new {roomId = result.Value}, null);
        }

        [HttpPut("{roomId}")]
        public async Task<IActionResult> EditRoomAsync(int roomId, [FromBody] EditedRoomDto room)
        {
            if (roomId != room.RoomId)
                return BadRequest();
            var result = await _commandDispatcher.DispatchAsync(new EditRoomCommand(room));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return Ok(result.Value);
        }

    }
}