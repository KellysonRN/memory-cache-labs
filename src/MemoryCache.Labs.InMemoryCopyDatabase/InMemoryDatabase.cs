using System.Collections.Concurrent;
using MemoryCache.Labs.Infrastructure.Exceptions;
using MemoryCache.Labs.Infrastructure.Repositories;

namespace MemoryCache.Labs.InMemoryCopyDatabase;

public class InMemoryDatabase : IMemoryDatabase
{
    private readonly ConcurrentDictionary<object, BoardGameCacheRecord> _copyDatabase = new();
    
    public BoardGameCacheRecord AddData(object key, BoardGameCacheRecord data)
    {
        if (_copyDatabase.TryAdd(key, data))
            return GetData(key);

        throw new RecordAlreadyExistsException();
    }

    public bool ContainsData(object key)
    {
        return _copyDatabase.ContainsKey(key);
    }

    public BoardGameCacheRecord GetData(object key)
    {
        _copyDatabase.TryGetValue(key, out BoardGameCacheRecord? data);
        
        return data ?? throw new NotFoundRecordException();
    }
}

