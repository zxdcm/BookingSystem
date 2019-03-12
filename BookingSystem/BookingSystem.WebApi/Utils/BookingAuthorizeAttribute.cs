using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Common.Utils;
using BookingSystem.Queries.Queries.BookingQueries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.WebApi.Utils
{
    public class BookingAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            
            if (context.HttpContext.User.Claims
                .Any(c => c.Type == ClaimTypes.Role && c.Value == RoleName.Admin))
            {
                return;
            }
            var bookingId = int.Parse(context.RouteData.Values.GetValueOrDefault("bookingId", 0).ToString());
            var userId = int.Parse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            if (userId == 0)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var queryDispatcher = context.HttpContext.RequestServices.GetRequiredService<IQueryDispatcher>();
            var canAccess = await queryDispatcher.DispatchAsync(new UserCanAccessBookingQuery(bookingId, userId));
            if (canAccess == false)
            {
                context.Result = new UnauthorizedResult();
            }

        }
    }
}
