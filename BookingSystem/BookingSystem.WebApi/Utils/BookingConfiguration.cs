using BookingSystem.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookingSystem.WebApi.Utils
{
    public class BookingConfiguration : IBookingConfiguration
    {
        public int LockTimeOutMinutes => _configuration.GetValue("BookingRules:TimeOutMinutes", 30);

        private readonly IConfiguration _configuration;

        public BookingConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }        
    }
}
