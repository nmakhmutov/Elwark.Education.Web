using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
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
    private IHistoryUserService UserService { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Assignments_Title"], null, true),
    ];
    
    protected override async Task OnInitializedAsync() =>
        _result = await UserService.GetAssignmentsAsync();

    private async Task ClaimDailyBonusAsync() =>
        _result = (await UserService.ClaimDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with { DailyBonus = bonus });

    private async Task RejectDailyBonusAsync() =>
        _result = (await UserService.RejectDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with { DailyBonus = bonus });

    private async Task StartDailyQuestsAsync() =>
        _result = (await UserService.StartDailyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { DailyAssignments = assignments });

    private async Task CollectDailyQuestsAsync() =>
        _result = (await UserService.CollectDailyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { DailyAssignments = assignments });

    private async Task StartWeeklyQuestsAsync() =>
        _result = (await UserService.StartWeeklyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { WeeklyAssignments = assignments });

    private async Task CollectWeeklyQuestsAsync() =>
        _result = (await UserService.CollectWeeklyAssignmentsAsync())
            .Map(assignments => _result.Unwrap() with { WeeklyAssignments = assignments });
}
