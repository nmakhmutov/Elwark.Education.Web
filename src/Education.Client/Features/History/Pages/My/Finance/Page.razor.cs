using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Finance;

public sealed partial class Page
{
    private ApiResult<FinanceModel> _result = ApiResult<FinanceModel>.Loading();

    [Inject]
    public IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;
    
    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;
    
    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Finance_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _result = await UserClient.GetFinancesAsync();
}
