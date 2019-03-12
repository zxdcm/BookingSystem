using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Queries.Queries.UserQueries.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookingSystem.WebApi.JwtProvider
{
    public class JwtGenerator 
    {
        private readonly JwtOptions _options;

        public JwtGenerator(JwtOptions options)
        {
            _options = options;
        }

        public IEnumerable<Claim> CreateClaims(UserView user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var roleClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role));
            return claims.Concat(roleClaims);
        }

        public string GenerateAccessToken(UserView user)
        {
            var credentials = new SigningCredentials(_options.Key, _options.Algorithm);
            var currentTime = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                Subject = new ClaimsIdentity(CreateClaims(user)),
                NotBefore = currentTime,
                Expires = currentTime.Add(_options.Expiration),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            ClaimsIdentity identity = new ClaimsIdentity();
            return tokenHandler.WriteToken(token);
        }
    }
}
