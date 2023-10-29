using MemoryCache.Labs.Infrastructure.Repositories;

namespace MemoryCache.Labs.InMemoryCopyDatabase;

public interface IMemoryDatabase
{
    BoardGameCacheRecord AddData(object key, BoardGameCacheRecord data);

    bool ContainsData(object key);

    BoardGameCacheRecord GetData(object key);
}
