using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookingSystem.WebApi.Utils
{
    public static class UserExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal) 
            => int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
    }
}
