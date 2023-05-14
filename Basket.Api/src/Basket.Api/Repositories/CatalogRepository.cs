using Basket.Api.Controllers;
using Basket.Api.Integration;

namespace Basket.Api.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ICatalogIntegration _catalogIntegration;

    private IReadOnlyCollection<ProductModel> _products;

    public CatalogRepository(ICatalogIntegration catalogIntegration)
    {
        _products = new List<ProductModel>();
        _catalogIntegration = catalogIntegration;
    }

    public async Task<PageWithTotalModel<ProductModel>> GetProductsAsync(int? skip, int? take, CancellationToken ct)
    {
        if (_products.Count == 0)
        {
            _products = await _catalogIntegration.ProductAllAsync(ct);
        }

        var s = skip ?? 0;
        var t = take ?? 100;
        var paged = _products.Skip(s).Take(t).ToArray();
        return new PageWithTotalModel<ProductModel>(s, t, paged, _products.Count);
    }

    public Task<IReadOnlyCollection<ProductModel>> GetCheapestProductAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ProductModel>> GetTopRankedProductAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}