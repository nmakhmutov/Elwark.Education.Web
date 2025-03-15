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
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IHistoryProductClient _productClient;
    private readonly IHistoryUserClient _userClient;
    private CategoryType[] _categories = [];
    private CategoryType _category;
    private ProfileModel _profile = ProfileModel.Empty;
    private ApiResult<Product[]> _response = ApiResult<Product[]>.Loading();

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryUserClient userClient,
        IHistoryProductClient productClient,
        IDialogService dialogService,
        NavigationManager navigation
    )
    {
        _localizer = localizer;
        _userClient = userClient;
        _productClient = productClient;
        _dialogService = dialogService;
        _navigation = navigation;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["InventoryStore_Title"], null, true)
        ];
    }

    [SupplyParameterFromQuery]
    public string? Category { get; set; }

    [SupplyParameterFromQuery(Name = "id")]
    public int? InventoryId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await UpdateProfileAsync();

        _response = await _productClient.GetAsync();
        _categories = _response.Map(products => products.SelectMany(x => x.Categories).Append(CategoryType.None))
            .UnwrapOrElse(() => [])
            .Distinct()
            .Order()
            .ToArray();

        if (!InventoryId.HasValue)
            return;

        _response.Match(model =>
        {
            var inventory = model.OfType<Product.SystemModel>()
                .FirstOrDefault(x => x.InventoryId == InventoryId);

            if (inventory is null)
                return;

            _ = OpenInventoryDialog(inventory);
        });
    }

    protected override void OnParametersSet() =>
        _category = Enum.TryParse(Category, true, out CategoryType category) ? category : CategoryType.None;

    private async Task UpdateProfileAsync()
    {
        var profile = await _userClient.GetProfileAsync();

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
            CloseButton = false
        };

        var parameters = new DialogParameters<InventoryDialog>
        {
            {
                x => x.Product, product
            },
            {
                x => x.Profile, _profile
            }
        };

        var dialog = await _dialogService.ShowAsync<InventoryDialog>(product.Title, parameters, options);
        var result = await dialog.Result;
        if (result?.Canceled == true)
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
            CloseButton = false
        };

        var parameters = new DialogParameters<BundleDialog>
        {
            {
                x => x.Product, product
            },
            {
                x => x.Profile, _profile
            }
        };

        var dialog = await _dialogService.ShowAsync<BundleDialog>(product.Title, parameters, options);
        var result = await dialog.Result;
        if (result?.Canceled == true)
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
        _navigation.NavigateTo(HistoryUrl.Store.Index(category));
}
