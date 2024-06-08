using Education.Client.Clients;
using Education.Client.Features.History.Clients.Product;
using Education.Client.Features.History.Clients.Product.Model;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Pages.Store.Components;
using Education.Client.Models.Inventory;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Store;

public sealed partial class Page : ComponentBase
{
    private CategoryType[] _categories = [];
    private CategoryType _category;
    private ProfileModel _profile = ProfileModel.Empty;
    private ApiResult<Product[]> _response = ApiResult<Product[]>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private IHistoryProductClient ProductClient { get; init; } = default!;

    [Inject]
    private IDialogService DialogService { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Category { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["InventoryStore_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        await UpdateProfileAsync();

        _response = await ProductClient.GetAsync();
        _categories = _response.Map(products => products.SelectMany(x => x.Categories).Append(CategoryType.None))
            .UnwrapOrElse(() => [])
            .Distinct()
            .Order()
            .ToArray();
    }

    protected override void OnParametersSet() =>
        _category = Enum.TryParse(Category, true, out CategoryType category) ? category : CategoryType.None;

    private async Task UpdateProfileAsync()
    {
        var profile = await UserClient.GetProfileAsync();

        _profile = profile.Map(x => x)
            .UnwrapOrElse(() => ProfileModel.Empty);
    }

    private async Task OpenInventoryDialog(Product product)
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            CloseOnEscapeKey = true,
            FullWidth = true,
            NoHeader = true,
            CloseButton = false
        };

        var parameters = new DialogParameters
        {
            [nameof(InventoryDialog.Product)] = product,
            [nameof(InventoryDialog.Profile)] = _profile
        };

        var dialog = await DialogService.ShowAsync<InventoryDialog>(product.Title, parameters, options);
        var result = await dialog.Result;
        if (result.Canceled)
            return;

        await UpdateProfileAsync();
    }

    private async Task OpenBundleDialog(Product.BundleModel product)
    {
        var options = new DialogOptions
        {
            MaxWidth = product.Inventories.Length > 3 ? MaxWidth.Medium : MaxWidth.Small,
            CloseOnEscapeKey = true,
            FullWidth = true,
            NoHeader = true,
            CloseButton = false
        };

        var parameters = new DialogParameters
        {
            [nameof(BundleDialog.Product)] = product,
            [nameof(BundleDialog.Profile)] = _profile
        };

        var dialog = await DialogService.ShowAsync<BundleDialog>(product.Title, parameters, options);
        var result = await dialog.Result;
        if (result.Canceled)
            return;

        await UpdateProfileAsync();
    }

    private bool IsAffordable(Product inventory)
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
