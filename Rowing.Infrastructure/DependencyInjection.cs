using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Rowing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration  configuration)
    {
        //services.AddScoped<IDatabaseSetupService, DatabaseSetupService>();
        //register other database setup services

        return services;
    }
}