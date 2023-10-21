using MemoryCache.Labs.API.Controllers;
using MemoryCache.Labs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace MemoryCache.Labs.Tests;

public class BoardgamesControllerTests
{
    [Fact]
    public async void GetCollectionById_ShouldReturnCorrectResponse()
    {
        var record = new BoardGameCacheRecord(1, "Splendor", Link: "http://www.google.com");

        var cache = new Mock<ICachedBoardGames>();

        cache.Setup(x => x.GetBoardGamesCollectionById(1))
            .ReturnsAsync(record);

        var controller = new BoardGamesController(new NullLogger<BoardGamesController>(), cache.Object);

        var result = await controller.GetCollectionById(1);

        Assert.IsType<OkObjectResult>(result);

        var responseObj = result as OkObjectResult;
        Assert.Equal(200, responseObj?.StatusCode);

        Assert.IsType<BoardGameCacheRecord>(responseObj?.Value);

        var responseValue = responseObj?.Value as BoardGameCacheRecord;
        Assert.Equal(1, responseValue?.Id);
        Assert.Equal("Splendor", responseValue?.Name);
        Assert.Equal("http://www.google.com", responseValue?.Link);
    }
}
