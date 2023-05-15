using System.Net.Http.Json;
using System.Text.Json;
using Basket.Api.Controllers;

namespace BasketApi.Tests.ControllerTests;

public class BasketControllerTests : IClassFixture<ApiFactory>
{
    private const string api = "api/baskets";
    private readonly HttpClient _client;

    private readonly ApiFactory
        _factory;

    public BasketControllerTests(ApiFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateDefaultClient();
    }

    [Fact]
    public async void Create()
    {
        var endpoint = $"{api}/create/thacio.pacifico@gmail.com";
        var basket = new CreateBasketModel()
        {
            Products = new[]
            {
                new ProductModel()
                {
                    Id = 9239,
                    Price = 44.86m
                }
            }
        };
        var x = JsonSerializer.Serialize(basket, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
        var result = await _client.PostAsJsonAsync(endpoint, x);

        result.EnsureSuccessStatusCode();
    }
}