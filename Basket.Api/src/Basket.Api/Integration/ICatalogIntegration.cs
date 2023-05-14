using Basket.Api.Controllers;

namespace Basket.Api.Integration;

public interface ICatalogIntegration
{
    public Task<IReadOnlyCollection<ProductModel>> ProductAllAsync(CancellationToken ct);
    public Task<TokenModel> GetTokenAsync(CancellationToken ct);
}

public class TokenModel
{
    public string Token { get; set; }
}

public class RequestTokenModel
{
    public string Email { get; set; }
}