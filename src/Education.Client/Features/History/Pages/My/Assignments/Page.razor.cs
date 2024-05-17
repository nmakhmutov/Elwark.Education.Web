using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Clients.User.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Assignments;

public sealed partial class Page: ComponentBase
{
    private ApiResult<UserAssignmentModel> _result = ApiResult<UserAssignmentModel>.Loading();
    private MudTabs? _tabs;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Parameter, SupplyParameterFromQuery]
    public string? Tab { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Assignments_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _result = await UserClient.GetAssignmentsAsync();

    protected override void OnAfterRender(bool firstRender)
    {
        if (_tabs is not null && Tab is not null)
            _tabs.ActivatePanel(Tab);
    }

    private async Task ClaimDailyBonusAsync() =>
        _result = (await UserClient.ClaimDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with
            {
                DailyBonus = bonus
            });

    private async Task RejectDailyBonusAsync() =>
        _result = (await UserClient.RejectDailyBonusAsync())
            .Map(bonus => _result.Unwrap() with
            {
                DailyBonus = bonus
            });

    private async Task StartDailyQuestsAsync() =>
        _result = (await UserClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Daily)))
            .Map(assignments => _result.Unwrap() with
            {
                DailyAssignments = assignments
            });

    private async Task CollectDailyQuestsAsync(string id) =>
        _result = (await UserClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Daily)))
            .Map(assignments => _result.Unwrap() with
            {
                DailyAssignments = assignments
            });

    private async Task StartWeeklyQuestsAsync() =>
        _result = (await UserClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Weekly)))
            .Map(assignments => _result.Unwrap() with
            {
                WeeklyAssignments = assignments
            });

    private async Task CollectWeeklyQuestsAsync(string id) =>
        _result = (await UserClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Weekly)))
            .Map(assignments => _result.Unwrap() with
            {
                WeeklyAssignments = assignments
            });
}
