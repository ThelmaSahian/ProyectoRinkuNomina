using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Services;
using RinkuNomina.Domain.IRepositories;
using RinkuNomina.Infrastructure.Repositories;

namespace ProyectoRinkuApi.Configuration
{
    public static class ConfigurationRepositories
    {
        public static IServiceCollection AddConfigurationRepositories(this IServiceCollection service)
        {
            service.AddScoped<IRinkuNominaService, RinkuNominaService>();
            service.AddScoped<IRinkuNominaRepository, RinkuNominaRepository>();
            return service;
        }
    }
}
