using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[Route("api/catalog")]
public class CatalogController
{
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(ILogger<CatalogController> logger)
    {
        _logger = logger;
    }

    [HttpGet("products")]
    [ProducesResponseType(typeof(PageWithTotalModel<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> GetProducts(int? skip, int? take, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("products/top-ranked")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> GetTopTankedProductsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("products/cheapest")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> GetCheapestProductsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}


public class ProductModel
{
    public long Id { get; set; }
    
}