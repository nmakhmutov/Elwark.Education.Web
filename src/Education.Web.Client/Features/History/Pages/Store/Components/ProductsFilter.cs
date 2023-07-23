using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Pages.Store.Components;

public sealed record ProductsFilter(string? Search, CategoryType Category, ProductSort Sort)
{
    public static ProductsFilter Empty =>
        new(null, CategoryType.None, ProductSort.Featured);
}

public enum ProductSort
{
    Featured,
    PriceAsc,
    PriceDesc,
    DiscountAsc,
    DiscountDesc,
    Title
}
