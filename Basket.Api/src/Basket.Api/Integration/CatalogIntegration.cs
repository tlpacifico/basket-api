using System.Text.Json;
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

    public async Task<TokenModel> GetTokenAsync(CancellationToken ct)
    {
        var email = "thacio.pacifico@gmail.com";
        var response = await _httpClient.PostAsJsonAsync("Login", new RequestTokenModel() { Email = email }, ct);
        var token = JsonSerializer.Deserialize<TokenModel>(await response.Content.ReadAsStringAsync());
        return token;
    }
}