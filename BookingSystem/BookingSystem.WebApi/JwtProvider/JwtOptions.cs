using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookingSystem.WebApi.JwtProvider
{
    public class JwtOptions
    {
        public string Algorithm { get; set; }
        public string Audience { get; }
        public string Issuer { get; }
        public SecurityKey Key { get; }
        public TimeSpan Expiration { get; }

        public JwtOptions(TokenValidationParameters parameters, 
                          string algorithm = SecurityAlgorithms.HmacSha256Signature,
                          TimeSpan? expiration = null)
        {
            Algorithm = algorithm;
            Audience = parameters.ValidAudience;
            Issuer = parameters.ValidIssuer;
            Key = parameters.IssuerSigningKey;
            Expiration = expiration ?? TimeSpan.FromMinutes(30);
        }
    }
}
