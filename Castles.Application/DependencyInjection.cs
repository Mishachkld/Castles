using Castles.Application.Interfaces;
using Castles.Application.Repository;
using Castles.Application.Service;
using Castles.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Castles.Application.Mappings;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryCRUD<Castle>, CastleRepository>();
        services.AddScoped<CastleService>();
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new CastleMappingProfile()); 
        });

        return services;
    }
}