namespace Basket.Api.Controllers;

public class ProductModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int? Size { get; set; }
    public int? Stars { get; set; }
    
}