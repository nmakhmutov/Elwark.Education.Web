using Education.Client.Features.History.Clients.Product.Model;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Pages.Store;

internal static class StoreExtensions
{
    public static IEnumerable<Product> Filter(this IEnumerable<Product> products, CategoryType category) =>
        category == CategoryType.None ? products : products.Where(x => x.Categories.Contains(category));

    public static IOrderedEnumerable<IGrouping<string, Product>> Sort(this IEnumerable<Product> products) =>
        products.GroupBy(x => x is Product.BundleModel ? "Bundles" : "Inventories").OrderBy(x => x.Key);
}
