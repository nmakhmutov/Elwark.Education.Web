using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Orders;

public sealed partial class Orders : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryUserClient _userClient;
    private ApiResult<ProfileModel> _profile = ApiResult<ProfileModel>.Loading();

    public Orders(IStringLocalizer<App> localizer, IHistoryUserClient userClient)
    {
        _localizer = localizer;
        _userClient = userClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(localizer["Finance_Title"], HistoryUrl.User.MyFinance),
            new BreadcrumbItem(localizer["Orders_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync() =>
        _profile = await _userClient.GetProfileAsync();
}
