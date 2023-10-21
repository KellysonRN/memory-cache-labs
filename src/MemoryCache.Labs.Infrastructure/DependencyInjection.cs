using MemoryCache.Labs.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MemoryCache.Labs.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ILudopediaRepository, LudopediaRepository>();
        services.AddScoped<ICachedBoardGames, CachedBoardGames>();
    }
}
