using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.User;
using Education.Web.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Assignments;

public sealed partial class Page
{
    private ApiResult<UserAssignmentModel> _result = ApiResult<UserAssignmentModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Assignments_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _result = await UserClient.GetAssignmentsAsync();

    private async Task ClaimDailyBonusAsync() =>
        _result = (await UserClient.ClaimDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with { DailyBonus = bonus });

    private async Task RejectDailyBonusAsync() =>
        _result = (await UserClient.RejectDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with { DailyBonus = bonus });

    private async Task StartDailyQuestsAsync() =>
        _result = (await UserClient.StartDailyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { DailyAssignments = assignments });

    private async Task CollectDailyQuestsAsync() =>
        _result = (await UserClient.CollectDailyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { DailyAssignments = assignments });

    private async Task StartWeeklyQuestsAsync() =>
        _result = (await UserClient.StartWeeklyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { WeeklyAssignments = assignments });

    private async Task CollectWeeklyQuestsAsync() =>
        _result = (await UserClient.CollectWeeklyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { WeeklyAssignments = assignments });
}
