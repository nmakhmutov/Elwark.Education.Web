using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Quests;

public sealed partial class Page
{
    private int _index;
    private ApiResult<UserQuestModel> _result = ApiResult<UserQuestModel>.Loading();

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
        _result = await UserService.GetQuestAsync();

    private async Task ClaimDailyBonusAsync() =>
        _result = (await UserService.ClaimDailyBonusAsync())
            .Map(x => _result.Unwrap() with { DailyBonus = x });

    private async Task RejectDailyBonusAsync() =>
        _result = (await UserService.RejectDailyBonusAsync())
            .Map(x => _result.Unwrap() with { DailyBonus = x });

    private async Task StartDailyQuestsAsync() =>
        _result = (await UserService.StartDailyQuestAsync())
            .Map(x => _result.Unwrap() with { DailyQuests = x });

    private async Task CollectDailyQuestsAsync() =>
        _result = (await UserService.CollectDailyQuestAsync())
            .Map(x => _result.Unwrap() with { DailyQuests = x });

    private async Task StartWeeklyQuestsAsync() =>
        _result = (await UserService.StartWeeklyQuestAsync())
            .Map(x => _result.Unwrap() with { WeeklyQuests = x });

    private async Task CollectWeeklyQuestsAsync() =>
        _result = (await UserService.CollectWeeklyQuestAsync())
            .Map(x => _result.Unwrap() with { WeeklyQuests = x });
}
