using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[Route("api/baskets")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;

    public BasketController(ILogger<BasketController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost("create/{email}")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> CreateAsync(
        [FromRoute] string email,
        [FromBody] CreateBasketModel createBasketModel,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> GetAsync(
        [FromRoute] Guid id,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("{id:guid}/add-product")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> AddProductAsync(
        [FromRoute] Guid id,
        [FromBody] AddProductModel addProductModel,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("{id:guid}/remove-product")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<IActionResult> RemoveProductAsync(
        [FromRoute] Guid id,
        [FromBody] RemoveProductModel removeProductModel,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}

public class BasketModel
{
    
}


public class CreateBasketModel
{
    
}

public class AddProductModel
{
    
}

public class RemoveProductModel
{
    
}