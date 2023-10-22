
using MemoryCache.Labs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCache.Labs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardGamesController : ControllerBase
{
    private readonly ILogger<BoardGamesController> _logger;
    
    private readonly ICachedBoardGames _cachedBoardGames;

    public BoardGamesController(ILogger<BoardGamesController> logger, ICachedBoardGames cachedBoardGames)
    {
        _logger = logger;
        _cachedBoardGames = cachedBoardGames;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetMyCollection()
    {
        _logger.LogInformation($"GetMyCollection");
        
        var myCollection = await _cachedBoardGames.GetAll();
        return !myCollection.Any() ? NoContent() : Ok(myCollection);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetCollectionById(int id)
    {
        _logger.LogInformation($"GetCollectionById {id}");
        
        var myCollection = await _cachedBoardGames.GetBoardGamesCollectionById(id);
        return myCollection is null ? NoContent() : Ok(myCollection);
    }
    
    [HttpDelete()]
    public ActionResult InvalidateCache()
    {
        _logger.LogInformation($"InvalidateCache");
        
        _cachedBoardGames.InvalidateCache();
        
        return Ok();
    }
}
