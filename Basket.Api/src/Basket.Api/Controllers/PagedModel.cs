namespace Basket.Api.Controllers;

/// <summary>
/// Represents a pagination result
/// </summary>
/// <typeparam name="T">The items type</typeparam>
public class PageModel<T>
{
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <param name="items"></param>
    public PageModel(int skip, int take, T[] items)
    {
        Skip = skip;
        Take = take;
        Items = items;
    }
    /// <summary>
    /// The number of items skipped
    /// </summary>
    public int Skip { get; set; }

    /// <summary>
    /// The number of items taken
    /// </summary>
    public int Take { get; set; }

    /// <summary>
    /// The collection of items for this page
    /// </summary>
    public T[] Items { get; set; }
}