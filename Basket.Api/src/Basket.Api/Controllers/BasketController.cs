using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[Route("api/baskets")]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;
    private readonly IBasketRepository _basketRepository;

    public BasketController(ILogger<BasketController> logger, IBasketRepository basketRepository)
    {
        _logger = logger;
        _basketRepository = basketRepository;
    }

    [HttpPost("create/{email}")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    public IActionResult CreateAsync(
        [FromRoute] string email,
        [FromBody] CreateBasketModel createBasketModel)
    {
        var basket = _basketRepository.Create(email, createBasketModel);
        _logger.LogInformation("Creating basket");
        return Ok(basket);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAsync(
        [FromRoute] Guid id,
        CancellationToken ct)
    {
        var basket = _basketRepository.Get(id);
        if (basket is null) return NotFound();

        return Ok(basket);
    }

    [HttpPut("{id:guid}/add-product")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AddProductAsync(
        [FromRoute] Guid id,
        [FromBody] ProductModel addProductModel,
        CancellationToken ct)
    {
        var basket = _basketRepository.AddProduct(id, addProductModel);
        if (basket is null) return NotFound();

        return Ok(basket);
    }

    [HttpPut("{id:guid}/remove-product")]
    [ProducesResponseType(typeof(BasketModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult RemoveProductAsync(
        [FromRoute] Guid id,
        [FromBody] ProductModel removeProductModel,
        CancellationToken ct)
    {
        var basket = _basketRepository.RemoveProduct(id, removeProductModel);
        if (basket is null) return NotFound();

        return Ok(basket);
    }
}

public class BasketModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public List<ProductModel> Products { get; set; }
}

public class CreateBasketModel
{
    public IReadOnlyCollection<ProductModel> Products { get; set; }
}