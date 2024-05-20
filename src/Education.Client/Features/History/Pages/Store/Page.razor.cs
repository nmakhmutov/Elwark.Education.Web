using Education.Client.Features.History.Clients.Store.Model;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models.Inventory;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Store;

public sealed partial class Page : ComponentBase
{
    private const string InventoryTabId = "inventories";
    private const string BundleTabId = "bundles";

    private ProfileModel _profile = ProfileModel.Empty;
    private MudTabs? _tabs;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Tab { get; set; }

    [SupplyParameterFromQuery]
    public string? Category { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["InventoryStore_Title"], null, true)
    ];

    protected override Task OnInitializedAsync() =>
        UpdateProfileAsync();

    protected override void OnParametersSet()
    {
        if (!string.IsNullOrEmpty(Tab) && _tabs?.ActivePanel.ID.Equals(Tab) == false)
            _tabs?.ActivatePanel(Tab);
    }

    private async Task UpdateProfileAsync()
    {
        var profile = await UserClient.GetProfileAsync();

        _profile = profile.Map(x => x)
            .UnwrapOrElse(() => ProfileModel.Empty);
    }

    private bool IsInventoryAffordable(ProductInventoryModel inventory) =>
        IsAffordable(inventory.Selling, inventory.Weight);

    private bool IsBundleAffordable(ProductBundleModel bundle) =>
        IsAffordable(bundle.Price, bundle.Weight);

    private bool IsAffordable(PriceModel price, uint weight)
    {
        if (weight > _profile.Backpack.Emptiness)
            return false;

        if (_profile.Wallet.TryGetValue(price.Total.Currency, out var amount))
            return amount >= price.Total.Amount;

        return false;
    }

    private void ChangeTab(string tab) =>
        Navigation.NavigateTo(HistoryUrl.Store.Index(tab));

    private void ChangeCategory(CategoryType category) =>
        Navigation.NavigateTo(HistoryUrl.Store.Index(Tab ?? InventoryTabId, category));
}
