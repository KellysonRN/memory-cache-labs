using MemoryCache.Labs.Infrastructure.Exceptions;
using MemoryCache.Labs.Infrastructure.Repositories;
using MemoryCache.Labs.InMemoryCopyDatabase;

namespace MemoryCache.Labs.Tests;

public class DatabaseInMemoryTests
{
    [Fact]
    public void AddData_ShouldAddCorrectly()
    {
        IMemoryDatabase inMemoryDatabase = new InMemoryDatabase();
        
        inMemoryDatabase.AddData(key: 1, data: new BoardGameCacheRecord(Id: 1, Name: "Board1", Link: "https://www.lipsum.com/"));

        Assert.True(inMemoryDatabase.ContainsData(1));
        Assert.Equal("Board1", inMemoryDatabase.GetData(1).Name);
    }
    
    [Fact]
    public void AddData_ShouldThrowException()
    {
        IMemoryDatabase inMemoryDatabase = new InMemoryDatabase();
        
        inMemoryDatabase.AddData(key: 1, data: new BoardGameCacheRecord(Id: 1, Name: "Board1", Link: "https://www.lipsum.com/"));

        Assert.True(inMemoryDatabase.ContainsData(1));
        
        Assert.Throws<RecordAlreadyExistsException>(() =>
        {
            inMemoryDatabase.AddData(key: 1,
                data: new BoardGameCacheRecord(Id: 1, Name: It.IsAny<string>(), Link: It.IsAny<string>()));
        });
    }
    
    [Fact]
    public void DataRead_ShouldBeThreadSafe()
    {
        var inMemoryDatabase = new InMemoryDatabase();
        inMemoryDatabase.AddData(key: 1, data: new BoardGameCacheRecord(Id: 1, Name: "Board1", Link: "https://www.lipsum.com/"));

        var result1 = inMemoryDatabase.GetData(1).Name;
        var result2 = inMemoryDatabase.GetData(1).Name;

        Assert.Equal(result1, result2);
    }
    
    [Fact]
    public void DataRead_ShouldThowException()
    {
        var inMemoryDatabase = new InMemoryDatabase();
        inMemoryDatabase.AddData(key: 1, data: new BoardGameCacheRecord(Id: 1, Name: "Board1", Link: "https://www.lipsum.com/"));

        Assert.Throws<NotFoundRecordException>(() =>
        {
            _ = inMemoryDatabase.GetData(2).Name;
        });
    }
}
