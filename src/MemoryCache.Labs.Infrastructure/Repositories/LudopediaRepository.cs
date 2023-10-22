using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MemoryCache.Labs.Infrastructure.Repositories;

public interface ILudopediaRepository
{
    Task<IEnumerable<BoardGameDto>?> GetAll();
}

public class LudopediaRepository : ILudopediaRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LudopediaRepository(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;
    
    public async Task<IEnumerable<BoardGameDto>?> GetAll()
    {
        const string apiUrl = $"https://ludopedia.com.br/api/v1/colecao";
        
        var httpClient = _httpClientFactory.CreateClient(AppConstants.HTTP_CLIENT_NAME);
        var response = await httpClient.GetAsync(
            apiUrl);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
            
            return new List<BoardGameDto>();
        }

        string httpContent = await response.Content.ReadAsStringAsync();

        var boardGames = JsonSerializer.Deserialize<LudopediaResponse>(httpContent);
                
        return boardGames?.MyCollection;
    }
}

public record LudopediaResponse(List<BoardGameDto>? MyCollection)
{
    [JsonPropertyName("colecao")] public List<BoardGameDto>? MyCollection { get; set; } = MyCollection;
}

public abstract record BoardGameDto([property: JsonPropertyName("id_jogo")]
    int Id, string? Name, string? Link)
{
    [JsonPropertyName("nm_jogo")]
    public string? Name { get; } = Name;

    [JsonPropertyName("link")]
    public string? Link { get; } = Link;
}
