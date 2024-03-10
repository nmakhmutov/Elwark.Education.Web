using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Pages.My.Backpack.Components;
using Education.Client.Models.Inventory;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Backpack;

public sealed partial class Page
{
    private ProfileModel _profile = ProfileModel.Empty;
    private ApiResult<BackpackModel> _result = ApiResult<BackpackModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private IDialogService DialogService { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _profile = (await UserClient.GetProfileAsync())
            .Map(x => x)
            .UnwrapOrElse(() => _profile);

        _result = await UserClient.GetBackpackAsync();
    }

    private async Task OpenDialogAsync(BackpackInventoryModel inventory)
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            CloseButton = false,
            NoHeader = true
        };

        var parameters = new DialogParameters
        {
            [nameof(InventoryDialog.ProductId)] = inventory.ProductId,
            [nameof(InventoryDialog.ProductQuantity)] = inventory.Quantity
        };

        var dialog = await DialogService.ShowAsync<InventoryDialog>(inventory.Title, parameters, options);
        var result = await dialog.Result;
        if (result.Canceled)
            return;

        await OnInitializedAsync();
    }
}
