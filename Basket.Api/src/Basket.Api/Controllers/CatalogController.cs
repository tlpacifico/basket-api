using Basket.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[Route("api/catalog")]
public class CatalogController : ControllerBase
{
    private readonly ILogger<CatalogController> _logger;
    private readonly ICatalogRepository _catalogRepository;
    public CatalogController(ILogger<CatalogController> logger, ICatalogRepository catalogRepository)
    {
        _logger = logger;
        _catalogRepository = catalogRepository;
    }

    [HttpGet("products")]
    [ProducesResponseType(typeof(PageWithTotalModel<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProducts(int? skip, int? take, CancellationToken ct)
    {
        if (take > 1000)
        {
            return BadRequest();
        }

        var result =  await _catalogRepository.GetProductsAsync(skip, take, ct);
        return Ok(result);
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