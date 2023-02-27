using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Pages.Store;

public enum Sort
{
    Featured,
    PriceAsc,
    PriceDesc,
    DiscountAsc,
    DiscountDesc,
    Title
}

public sealed record ProductsFilter(CategoryType Category, Sort Sort)
{
    public static ProductsFilter Empty =>
        new (CategoryType.None, Sort.Featured);
}

internal static class Extensions
{
    public static IReadOnlyCollection<ProductDto> Apply(this IQueryable<ProductDto> source, ProductsFilter filter)
    {
        if (filter.Category != CategoryType.None)
            source = source.Where(x => x.Product.Inventories.Any(t => t.Category.Type == filter.Category));

        source = filter.Sort switch
        {
            Sort.Featured => source,
            Sort.PriceAsc => source.OrderBy(x => x.Product.Selling.Total.Amount),
            Sort.PriceDesc => source.OrderByDescending(x => x.Product.Selling.Total.Amount),
            Sort.DiscountAsc => source.OrderBy(x => x.Product.Selling.Discount),
            Sort.DiscountDesc => source.OrderByDescending(x => x.Product.Selling.Discount),
            Sort.Title => source.OrderBy(x => x.Product.Title),
            _ => throw new ArgumentOutOfRangeException()
        };

        return source.ToArray();
    }
}