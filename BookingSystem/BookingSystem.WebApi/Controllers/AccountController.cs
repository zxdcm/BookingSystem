using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Commands.Commands.AccountCommands.Commands;
using BookingSystem.Commands.Commands.AccountCommands.DTOs;
using BookingSystem.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingSystem.WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<BookingController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AccountController(ILogger<BookingController> logger, 
            ICommandDispatcher commandDispatcher, 
            IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public string GetProfileInfo(int id)
        {
            return null;
        }

        // POST: api/Account/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto user)
        {
            var result = await _commandDispatcher.DispatchAsync(new SignInCommand(user));
            if (result.IsSuccessful == false)
                return UnprocessableEntity(result);
            return CreatedAtAction(nameof(GetProfileInfo), new { id = result.Value }, null);

        }

        // POST: api/Account/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto user)
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
