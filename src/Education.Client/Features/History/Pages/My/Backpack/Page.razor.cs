using Education.Client.Clients;
using Education.Client.Features.History.Clients.Product;
using Education.Client.Features.History.Clients.Product.Model;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Layout;
using Education.Client.Models.Inventory;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Backpack;

public sealed partial class Page : ComponentBase,
    IDisposable
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryProductClient _productClient;
    private readonly IHistoryUserClient _userClient;
    private ApiResult<BackpackModel> _backpack = ApiResult<BackpackModel>.Loading();
    private string? _containerClass;
    private ApiResult<ProductOverviewModel> _product = ApiResult<ProductOverviewModel>.Loading();
    private ProfileModel _profile = ProfileModel.Empty;
    private BackpackInventoryModel? _selectedInventory;

    public Page(IStringLocalizer<App> localizer, IHistoryUserClient userClient, IHistoryProductClient productClient)
    {
        _localizer = localizer;
        _userClient = userClient;
        _productClient = productClient;
    }

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    [CascadingParameter]
    public HistoryLayout Layout { get; set; } = default!;

    public void Dispose() =>
        Layout.ShowFooter();

    protected override async Task OnInitializedAsync()
    {
        Layout.HideFooter();

        var response = await _userClient.GetProfileAsync();
        _profile = response.Map(x => x)
            .UnwrapOrElse(() => _profile);

        _backpack = await _userClient.GetBackpackAsync();

        _selectedInventory = _backpack.Map(x => x.Items.FirstOrDefault())
            .UnwrapOr(null);

        if (_selectedInventory is not null)
            await OnInventorySelected(_selectedInventory);
    }

    private void OnBackClick() =>
        _containerClass = "inventories-mode";

    private async Task OnInventorySelected(BackpackInventoryModel inventory)
    {
        _containerClass = "details-mode";
        _selectedInventory = inventory;

        _product = ApiResult<ProductOverviewModel>.Loading();
        _product = await _productClient.GetAsync(inventory.ProductId);
    }
}
