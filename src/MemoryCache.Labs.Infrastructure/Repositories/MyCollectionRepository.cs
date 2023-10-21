using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache.Labs.Infrastructure.Repositories;

public interface ICachedBoardGames
{
    Task<IReadOnlyList<BoardGameCacheRecord?>> GetAll();

    Task<BoardGameCacheRecord?> GetBoardGamesCollectionById(int id);

    void InvalidateCache();
}

public class CachedBoardGames : ICachedBoardGames
{
    private const string CacheKey = nameof(CachedBoardGames);

    private readonly ILudopediaRepository _ludopediaRepository;

    private readonly IMemoryCache _cache;

    public CachedBoardGames(IMemoryCache cache, ILudopediaRepository ludopediaRepository)
    {
        _cache = cache;
        _ludopediaRepository = ludopediaRepository;
    }

    public async Task<IReadOnlyList<BoardGameCacheRecord?>> GetAll()
    {
        if (_cache.TryGetValue(CacheKey, out IReadOnlyList<BoardGameCacheRecord?>? result))
        {
            if (result is not null)
            {
                return result;
            }
        }

        var departments = await _ludopediaRepository.GetAll();
            
        result = departments.Select(x => new BoardGameCacheRecord(x.Id, x.Name, x.Link)).ToList();
            
        var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));
            
        _cache.Set(CacheKey, result, options);

        return result;
    }

    public async Task<BoardGameCacheRecord?> GetBoardGamesCollectionById(int id)
    {
        var allCachedUserNames = await GetAll();
        return allCachedUserNames.FirstOrDefault(x => x is not null && x.Id == id) ?? null;
    }
    
    public void InvalidateCache()
    {
        _cache.Remove(CacheKey);
    }
}

public record BoardGameCacheRecord(int Id, string Name, string Link);
