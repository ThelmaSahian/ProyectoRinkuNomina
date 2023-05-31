using Microsoft.EntityFrameworkCore;
using RinkuNomina.Application;

namespace ProyectoRinkuApi.Configuration
{
    public static class ConfigurationDba
    {
        public static IServiceCollection AddConfigurationDba(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RinkuContext>(c => c.UseSqlServer(configuration.GetConnectionString("RinkuDb")));
            return service;
        }
    }
}
