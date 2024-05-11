using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Pages.Store.Components;

public sealed record ProductsFilter(CategoryType Category)
{
    public static ProductsFilter Empty =>
        new(CategoryType.None);
}
