using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Assignments;

public sealed partial class Page
{
    private int _index;
    private ApiResult<UserAssignmentModel> _result = ApiResult<UserAssignmentModel>.Loading();

    private List<BreadcrumbItem> Breadcrumbs =>
        new()
        {
            new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile)
        };

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryUserService UserService { get; set; } = default!;

    protected override async Task OnInitializedAsync() =>
        _result = await UserService.GetAssignmentsAsync();

    private async Task ClaimDailyBonusAsync() =>
        _result = (await UserService.ClaimDailyBonusAsync())
            .Map(x => _result.Unwrap() with { DailyBonus = x });

    private async Task RejectDailyBonusAsync() =>
        _result = (await UserService.RejectDailyBonusAsync())
            .Map(x => _result.Unwrap() with { DailyBonus = x });

    private async Task StartDailyQuestsAsync() =>
        _result = (await UserService.StartDailyAssignmentsAsync())
            .Map(x => _result.Unwrap() with { DailyAssignments = x });

    private async Task CollectDailyQuestsAsync() =>
        _result = (await UserService.CollectDailyAssignmentsAsync())
            .Map(x => _result.Unwrap() with { DailyAssignments = x });

    private async Task StartWeeklyQuestsAsync() =>
        _result = (await UserService.StartWeeklyAssignmentsAsync())
            .Map(x => _result.Unwrap() with { WeeklyAssignments = x });

    private async Task CollectWeeklyQuestsAsync() =>
        _result = (await UserService.CollectWeeklyAssignmentsAsync())
            .Map(x => _result.Unwrap() with { WeeklyAssignments = x });
}
