namespace MemoryCache.Labs.Infrastructure.Repositories;

public interface ILudopediaRepository
{
    Task<IEnumerable<BoardGameDto>> GetAll();
}

public class LudopediaRepository : ILudopediaRepository
{
    public async Task<IEnumerable<BoardGameDto>> GetAll()
    {
        await Task.CompletedTask;
        return new List<BoardGameDto>
        {
            new(id: 1, name: "Splendor", link: ""),
            new(id: 2, name: "Pandemic", link: ""),
            new(id: 3, name: "Cyclades", link: ""),
        };
    }
}

public class BoardGameDto
{
    public BoardGameDto(int id, string name, string link)
    {
        Id = id;
        Name = name;
        Link = link;
    }

    public int Id { get; init; }

    public string Name { get; init; }

    public string Link { get; init; }
}
