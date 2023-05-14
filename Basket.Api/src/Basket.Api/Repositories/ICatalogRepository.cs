using Basket.Api.Controllers;

namespace Basket.Api.Repositories;

public interface ICatalogRepository
{
    public Task<PageWithTotalModel<ProductModel>> GetProductsAsync(int? skip, int? take, CancellationToken ct);
    public Task<IReadOnlyCollection<ProductModel>> GetCheapestProductAsync(CancellationToken ct);
    public Task<IReadOnlyCollection<ProductModel>> GetTopRankedProductAsync(CancellationToken ct);
}