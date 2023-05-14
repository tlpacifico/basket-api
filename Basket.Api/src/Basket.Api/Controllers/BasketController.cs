using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[Route("api/basket")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;

    public BasketController(ILogger<BasketController> logger)
    {
        _logger = logger;
    }
}