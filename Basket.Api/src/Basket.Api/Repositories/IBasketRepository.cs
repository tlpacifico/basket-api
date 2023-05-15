using Basket.Api.Controllers;

namespace Basket.Api.Repositories;

public interface IBasketRepository
{
    public BasketModel Create(string email, CreateBasketModel model);
    public BasketModel? Get(Guid id);
    public BasketModel? AddProduct(Guid id, ProductModel product);
    public BasketModel? RemoveProduct(Guid id, ProductModel product);
}