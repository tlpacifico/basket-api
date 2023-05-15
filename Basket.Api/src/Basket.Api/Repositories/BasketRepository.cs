using Basket.Api.Controllers;

namespace Basket.Api.Repositories;

public class BasketRepository : IBasketRepository
{
    private List<BasketModel> _baskets;

    public BasketRepository()
    {
        _baskets = new List<BasketModel>();
    }

    public BasketModel Create(string email, CreateBasketModel model)
    {
        var hasBasket = _baskets.FirstOrDefault(d => d.Email.ToUpper() == email.ToUpper());

        if (hasBasket is not null)
            return hasBasket;
        //TODO: check is product exists in the catalog
        var createdBasket = new BasketModel()
        {
            Id = Guid.NewGuid(),
            Email = email,
            Products = model.Products.ToList()
        };

        _baskets.Add(createdBasket);
        return createdBasket;
    }

    public BasketModel? Get(Guid id)
    {
        return _baskets.FirstOrDefault(p => p.Id == id);
    }

    public BasketModel? AddProduct(Guid id, ProductModel product)
    {
        var basket = Get(id);
        if (basket is null)
            return basket;
        
        //TODO: check is product exists in the catalog
        basket.Products.Add(product);
        return basket;
    }

    public BasketModel? RemoveProduct(Guid id, ProductModel product)
    {
        var basket = Get(id);
        if (basket is null)
            return basket;

        var prod = basket.Products.FirstOrDefault(p => p.Id == product.Id);

        if (prod is not null)
        {
            basket.Products.Remove(prod);
        }

        return basket;
    }
}