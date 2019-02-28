using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.WritePersistence.Utils
{
    internal class DesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<IPluralizer, CustomPluralizer>();
        }
    }
}
