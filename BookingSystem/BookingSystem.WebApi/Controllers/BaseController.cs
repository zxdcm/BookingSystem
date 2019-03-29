using BookingSystem.Commands.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Result.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccessful ? Ok() : Error(result.ErrorMessage);
        }


    }
}
