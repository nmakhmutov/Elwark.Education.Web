using Education.Client.Features.History.Clients.Product.Model;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models.Inventory;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Store;

public sealed partial class Page : ComponentBase
{
    private ProfileModel _profile = ProfileModel.Empty;
    private CategoryType _category;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Category { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["InventoryStore_Title"], null, true)
    ];

    protected override Task OnInitializedAsync() =>
        UpdateProfileAsync();

    protected override void OnParametersSet() =>
        _category = Enum.TryParse(Category, true, out CategoryType category) ? category : CategoryType.None;

    private async Task UpdateProfileAsync()
    {
        var profile = await UserClient.GetProfileAsync();

        _profile = profile.Map(x => x)
            .UnwrapOrElse(() => ProfileModel.Empty);
    }

    private bool IsInventoryAffordable(Product inventory)
    {
        if (inventory.Weight > _profile.Backpack.Emptiness)
            return false;

        if (_profile.Wallet.TryGetValue(inventory.Selling.Total.Currency, out var amount))
            return amount >= inventory.Selling.Total.Amount;

        return false;
    }

    private void ChangeCategory(CategoryType category) =>
        Navigation.NavigateTo(HistoryUrl.Store.Index(category));
}
