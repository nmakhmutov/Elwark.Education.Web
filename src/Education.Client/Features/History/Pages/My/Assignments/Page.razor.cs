using Education.Client.Clients;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Clients.User.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Assignments;

public sealed partial class Page : ComponentBase
{
    private ApiResult<UserAssignmentModel> _response = ApiResult<UserAssignmentModel>.Loading();
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
        _response = await UserClient.GetAssignmentsAsync();

    protected override void OnAfterRender(bool firstRender)
    {
        if (_tabs is not null && Tab is not null)
            _tabs.ActivatePanel(Tab);
    }

    private async Task ClaimDailyBonusAsync()
    {
        var response = await UserClient.ClaimDailyBonusAsync();
        _response = response
            .Map(bonus => _response.Unwrap() with
            {
                DailyBonus = bonus
            });
    }

    private async Task RejectDailyBonusAsync()
    {
        var response = await UserClient.RejectDailyBonusAsync();
        _response = response
            .Map(bonus => _response.Unwrap() with
            {
                DailyBonus = bonus
            });
    }

    private async Task StartDailyQuestsAsync()
    {
        var response = await UserClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Daily));
        _response = response
            .Map(assignments => _response.Unwrap() with
            {
                DailyAssignments = assignments
            });
    }

    private async Task CollectDailyQuestsAsync(string id)
    {
        var response = await UserClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Daily));

        _response = response
            .Map(x => _response.Unwrap() with
            {
                DailyAssignments = x
            });
    }

    private async Task StartWeeklyQuestsAsync()
    {
        var response = await UserClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Weekly));
        _response = response
            .Map(x => _response.Unwrap() with
            {
                WeeklyAssignments = x
            });
    }

    private async Task CollectWeeklyQuestsAsync(string id)
    {
        var response = await UserClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Weekly));
        _response = response
            .Map(assignments => _response.Unwrap() with
            {
                WeeklyAssignments = assignments
            });
    }
}
