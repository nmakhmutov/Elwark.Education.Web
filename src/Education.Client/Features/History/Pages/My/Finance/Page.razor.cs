using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Finance;

public sealed partial class Page : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryUserClient _userClient;
    private ApiResult<FinanceModel> _response = ApiResult<FinanceModel>.Loading();

    public Page(IStringLocalizer<App> localizer, IHistoryUserClient userClient)
    {
        _localizer = localizer;
        _userClient = userClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Finance_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync() =>
        _response = await _userClient.GetFinancesAsync();
}
