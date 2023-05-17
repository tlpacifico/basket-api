using System.Text.Json.Serialization;
using Basket.Api.Controllers;

namespace Basket.Api.Integration;

public interface ICatalogIntegration
{
    public Task<IReadOnlyCollection<ProductModel>> ProductAllAsync();
}

public class TokenModel
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}

public class RequestTokenModel
{
    public string Email { get; set; }
}