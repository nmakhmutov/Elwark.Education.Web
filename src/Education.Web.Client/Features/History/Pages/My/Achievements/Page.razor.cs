using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.User;
using Education.Web.Client.Features.History.Clients.User.Model;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Achievements;

public sealed partial class Page
{
    private ApiResult<AchievementsModel> _result = ApiResult<AchievementsModel>.Loading();
    private string? _subtitle;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Achievements_Title"], null, true)
    ];

    [CascadingParameter]
    private CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _result = await UserClient.GetAchievementsAsync();
        _subtitle = _result.Map(x => $"{x.Unlocked} / {x.Total}")
            .UnwrapOr(string.Empty);
    }
}
