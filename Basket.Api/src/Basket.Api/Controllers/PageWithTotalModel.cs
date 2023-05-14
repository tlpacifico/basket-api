namespace Basket.Api.Controllers;

/// <summary>
/// Represents a pagination result with a total
/// </summary>
/// <typeparam name="T">The items type</typeparam>
public class PageWithTotalModel<T> : PageModel<T>
{
   
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <param name="items"></param>
    /// <param name="total"></param>
    public PageWithTotalModel(int skip, int take, T[] items, int total) : base(skip, take, items)
    {
        Total = total;
    }

    /// <summary>
    /// The number of total items
    /// </summary>
    public long Total { get; set; }
}