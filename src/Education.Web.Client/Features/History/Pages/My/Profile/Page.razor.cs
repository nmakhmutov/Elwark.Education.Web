using Education.Web.Client.Features.History.Pages.My.Profile.Components;
using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Profile;

public sealed partial class Page
{
    private ApiResult<ProfileModel> _result = ApiResult<ProfileModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IDialogService DialogService { get; init; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; init; } = default!;

    protected override async Task OnInitializedAsync() =>
        _result = await UserService.GetProfileAsync();

    private async Task OnLevelClick()
    {
        if (_result.IsError)
            return;

        var options = new DialogOptions
        {
            FullWidth = true,
            MaxWidth = MaxWidth.Medium,
            CloseButton = false,
            NoHeader = true
        };

        var parameters = new DialogParameters
        {
            [nameof(NextLevelDialog.FullName)] = Customer.Name,
            [nameof(NextLevelDialog.Level)] = _result.Unwrap().Level
        };

        await DialogService.ShowAsync<NextLevelDialog>(string.Empty, parameters, options);
    }
}
