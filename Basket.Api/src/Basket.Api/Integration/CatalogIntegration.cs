using Basket.Api.Controllers;

namespace Basket.Api.Integration;

public class CatalogIntegration : ICatalogIntegration
{
    private readonly HttpClient _httpClient;
    private Lazy<ValueTask<IReadOnlyCollection<ProductModel>>> _products;
    
    public CatalogIntegration(HttpClient httpClient)
    {
        _products = new(LoadProducts);
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    private async ValueTask<IReadOnlyCollection<ProductModel>> LoadProducts()
    {
        //TODO: check is http code is 200
        var products = await _httpClient
            .GetFromJsonAsync<IReadOnlyCollection<ProductModel>>("GetAllProducts");
      
        return products;
    }

    public async Task<IReadOnlyCollection<ProductModel>> ProductAllAsync()
    {
        return await _products.Value;
    }
}