using Castles.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Castles.Database;

public static class DependenceInjection
{
    public static IServiceCollection AddCastlesDb(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        servicesCollection.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 2, 0)), // Указываем версию MySQL 8.2
                mysqlOptions =>
                {
                    mysqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });            options.EnableSensitiveDataLogging();
        }); 
        servicesCollection.AddScoped<ICastlesDbContext>(provider => provider.GetService<DatabaseContext>());
        return servicesCollection;
    }
}