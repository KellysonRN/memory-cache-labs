using System.Diagnostics.CodeAnalysis;
using MemoryCache.Labs.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MemoryCache.Labs.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ILudopediaRepository, LudopediaRepository>();
        services.AddScoped<ICachedBoardGames, CachedBoardGames>();
    }
}
