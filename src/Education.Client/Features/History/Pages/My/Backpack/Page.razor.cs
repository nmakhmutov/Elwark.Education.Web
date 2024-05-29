using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store;
using Education.Client.Features.History.Clients.Store.Model;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models.Inventory;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Backpack;

public sealed partial class Page : ComponentBase
{
    private string _containerClass = "";
    private BackpackInventoryModel? _selectedInventory;
    private ProfileModel _profile = ProfileModel.Empty;
    private ApiResult<BackpackModel> _backpack = ApiResult<BackpackModel>.Loading();
    private ApiResult<ProductOverviewModel> _product = ApiResult<ProductOverviewModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private IHistoryStoreClient StoreClient { get; init; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var response = await UserClient.GetProfileAsync();
        _profile = response
            .Map(x => x)
            .UnwrapOrElse(() => _profile);

        _backpack = await UserClient.GetBackpackAsync();

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
        _product = ApiResult<ProductOverviewModel>.Loading();

        _selectedInventory = inventory;
        _product = await StoreClient.GetProductAsync(inventory.ProductId);
    }
}
