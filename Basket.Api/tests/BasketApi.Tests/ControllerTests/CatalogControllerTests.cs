namespace BasketApi.Tests.ControllerTests;

public class CatalogControllerTests : IClassFixture<ApiFactory>
{
    private const string api = "api/catalog";
    private readonly HttpClient _client;

    private readonly ApiFactory
        _factory;
    
    public CatalogControllerTests(ApiFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateDefaultClient();
    }
    
    
    [Fact]
    public async void Get_Products_Paged()
    {
        var endpoint = $"{api}/products";
        var result = await _client.GetAsync(endpoint);

        result.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async void Get_Top_Ranked_Products()
    {
        var endpoint = $"{api}/products/top-ranked";
        var result = await _client.GetAsync(endpoint);

        result.EnsureSuccessStatusCode();
    }
    
    
    [Fact]
    public async void Get_Cheapest_Products()
    {
        var endpoint = $"{api}/products/cheapest";
        var result = await _client.GetAsync(endpoint);

        result.EnsureSuccessStatusCode();
    }

}