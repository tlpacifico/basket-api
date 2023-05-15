using Basket.Api.Controllers;
using Basket.Api.Integration;

namespace Basket.Api.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ICatalogIntegration _catalogIntegration;

    public CatalogRepository(ICatalogIntegration catalogIntegration)
    {
        _catalogIntegration = catalogIntegration;
    }

    public async Task<PageWithTotalModel<ProductModel>> GetProductsAsync(int? skip, int? take, CancellationToken ct)
    {
        var _products = await _catalogIntegration.ProductAllAsync(ct);

        var s = skip ?? 0;
        var t = take ?? 100;
        var paged = _products.Skip(s).Take(t).ToArray();
        return new PageWithTotalModel<ProductModel>(s, t, paged, _products.Count);
    }

    public async Task<IReadOnlyCollection<ProductModel>> GetCheapestProductAsync(CancellationToken ct)
    {
        var _products = await _catalogIntegration.ProductAllAsync(ct);

        return _products.OrderBy(p => p.Price).Take(100).ToArray();
    }

    public async Task<IReadOnlyCollection<ProductModel>> GetTopRankedProductAsync(CancellationToken ct)
    {
        var _products = await _catalogIntegration.ProductAllAsync(ct);

        return _products.OrderByDescending(p => p.Stars).Take(100).ToArray();
    }
}