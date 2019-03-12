using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.AccountCommands.Commands;
using BookingSystem.Commands.Commands.AccountCommands.DTOs;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.UserQueries.Queries;
using BookingSystem.Queries.Queries.UserQueries.Views;
using BookingSystem.WebApi.JwtProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<BookingController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly JwtGenerator _jwtGenerator;

        public AccountController(ILogger<BookingController> logger, 
            ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher, JwtGenerator jwtGenerator)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _jwtGenerator = jwtGenerator;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileInfo(int id)
        {
            var result = await _queryDispatcher.DispatchAsync(new UserDetailsQuery(id));
            if (result == null)
                return NotFound(id);
            return Ok(result);
        }

        // POST: api/Account/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] SignInDto user)
        {
            var result = await _commandDispatcher.DispatchAsync(new SignInCommand(user));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            var userId = result.Value.Value;
            var userView = await _queryDispatcher.DispatchAsync(new UserDetailsQuery(userId));
            var token = _jwtGenerator.GenerateAccessToken(userView);
            return CreatedAtAction(nameof(GetProfileInfo), new { id = result.Value }, token);

        }

        // POST: api/Account/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto user)
        {
            var result = await _commandDispatcher.DispatchAsync(new SignUpCommand(user));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetProfileInfo), new { id = result.Value }, null);

        }

        // POST: api/Account/signout
        [HttpDelete("signout")]
        public void SignOut(int id)
        {
        }
    }
}
