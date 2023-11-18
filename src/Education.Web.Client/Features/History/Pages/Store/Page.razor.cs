using Education.Web.Client.Features.History.Pages.Store.Components;
using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Store;

public sealed partial class Page
{
    private ProductsFilter _filter = ProductsFilter.Empty;
    private PossessionsModel _possessions = PossessionsModel.Empty;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Search { get; init; }

    protected override void OnParametersSet() =>
        _filter = _filter with { Search = Search };

    protected override Task OnInitializedAsync() =>
        LoadInventoryAsync();

    private async Task LoadInventoryAsync() =>
        _possessions = (await UserService.GetPossessionsAsync())
            .Map(x => x)
            .UnwrapOr(_possessions);

    private Task OnInventoryPurchased() =>
        LoadInventoryAsync();

    private Task OnBundlePurchased() =>
        LoadInventoryAsync();

    private bool IsInventoryAffordable(Product.InventoryModel inventory) =>
        IsAffordable(inventory.Selling, inventory.Weight);

    private bool IsBundleAffordable(Product.BundleModel bundle) =>
        IsAffordable(bundle.Price, bundle.Weight);

    private bool IsAffordable(Product.PriceModel price, uint weight)
    {
        if (weight > _possessions.Backpack.Emptiness)
            return false;

        if (_possessions.Wallet.TryGetValue(price.Total.Currency, out var amount))
            return amount >= price.Total.Amount;

        return false;
    }
}
