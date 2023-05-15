using Basket.Api.Controllers;

namespace Basket.Api.Integration;

public class CatalogIntegration : ICatalogIntegration
{
    private readonly HttpClient _httpClient;

    public CatalogIntegration(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IReadOnlyCollection<ProductModel>> ProductAllAsync(CancellationToken ct)
    {
        var response = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<ProductModel>>("GetAllProducts", ct);
        return response;
    }
}