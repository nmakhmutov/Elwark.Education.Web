using Education.Web.Client.Features.History.Clients.Store.Model;
using Education.Web.Client.Features.History.Clients.User;
using Education.Web.Client.Features.History.Clients.User.Model;
using Education.Web.Client.Features.History.Pages.Store.Components;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Store;

public sealed partial class Page
{
    private ProductsFilter _filter = ProductsFilter.Empty;
    private ProfileModel _profile = new(new UserLevelModel(0, 0, 0), new BackpackOverviewModel(0, 0, 0), []);

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Category { get; set; }

    protected override void OnParametersSet()
    {
        if (Enum.TryParse(Category, true, out CategoryType type))
            _filter = _filter with { Category = type };
    }

    protected override Task OnInitializedAsync() =>
        UpdateProfileAsync();

    private async Task UpdateProfileAsync() =>
        _profile = (await UserClient.GetProfileAsync())
            .Map(x => x)
            .UnwrapOrElse(() => _profile);

    private bool IsInventoryAffordable(Product.InventoryModel inventory) =>
        IsAffordable(inventory.Selling, inventory.Weight);

    private bool IsBundleAffordable(Product.BundleModel bundle) =>
        IsAffordable(bundle.Price, bundle.Weight);

    private bool IsAffordable(Product.PriceModel price, uint weight)
    {
        if (weight > _profile.Backpack.Emptiness)
            return false;

        if (_profile.Wallet.TryGetValue(price.Total.Currency, out var amount))
            return amount >= price.Total.Amount;

        return false;
    }
}
