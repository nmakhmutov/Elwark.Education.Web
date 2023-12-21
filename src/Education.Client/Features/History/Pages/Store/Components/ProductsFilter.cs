using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Pages.Store.Components;

public sealed record ProductsFilter(string? Search, CategoryType Category)
{
    public static ProductsFilter Empty =>
        new(null, CategoryType.None);
}
