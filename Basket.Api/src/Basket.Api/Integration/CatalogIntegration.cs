using Basket.Api.Controllers;

namespace Basket.Api.Integration;

public class CatalogIntegration : ICatalogIntegration
{
    private readonly HttpClient _httpClient;
    private IReadOnlyCollection<ProductModel> _products;
    public CatalogIntegration(HttpClient httpClient)
    {
        _products = new List<ProductModel>();
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IReadOnlyCollection<ProductModel>> ProductAllAsync(CancellationToken ct)
    {
        if (_products.Count > 0)
        {
            return _products;
        }
        _products = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<ProductModel>>("GetAllProducts", ct);
      
        return _products;
    }
}