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
}
