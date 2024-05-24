using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Achievements;

public sealed partial class Page : ComponentBase
{
    private ApiResult<AchievementsModel> _response = ApiResult<AchievementsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Achievements_Title"], null, true)
    ];

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync() =>
        _response = await UserClient.GetAchievementsAsync();
}
