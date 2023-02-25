using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Pages.Store;

public enum Sort
{
    PriceAsc,
    PriceDesc,
    DiscountAsc,
    DiscountDesc,
    NameAsc,
    NameDesc
}

public sealed record ProductsFilter(CategoryType Category, Sort Sort)
{
    public static ProductsFilter Empty =>
        new (CategoryType.None, Sort.PriceAsc);
}

public sealed record ProductData(ProductModel Product, bool IsAffordable);

internal static class Extensions
{
    public static IReadOnlyCollection<ProductData> Apply(this IQueryable<ProductData> source, ProductsFilter filter)
    {
        if (filter.Category != CategoryType.None)
            source = source.Where(x => x.Product.Inventories.Any(t => t.Category.Type == filter.Category));

        source = filter.Sort switch
        {
            Sort.PriceAsc => source.OrderBy(x => x.Product.Selling.Total.Amount),
            Sort.PriceDesc => source.OrderByDescending(x => x.Product.Selling.Total.Amount),
            Sort.DiscountAsc => source.OrderBy(x => x.Product.Selling.Discount),
            Sort.DiscountDesc => source.OrderByDescending(x => x.Product.Selling.Discount),
            Sort.NameAsc => source.OrderBy(x => x.Product.Title),
            Sort.NameDesc => source.OrderByDescending(x => x.Product.Title),
            _ => throw new ArgumentOutOfRangeException()
        };

        return source.ToArray();
    }
}