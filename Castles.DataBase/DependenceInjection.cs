using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Castles.Database;

public static class DependenceInjection
{
    public static IServiceCollection AddCastlesDb(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        return servicesCollection;
    }
}