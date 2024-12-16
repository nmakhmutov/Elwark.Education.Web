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
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryUserClient _userClient;
    private ApiResult<UserAssignmentModel> _response = ApiResult<UserAssignmentModel>.Loading();
    private MudTabs? _tabs;

    public Page(IHistoryUserClient userClient, IStringLocalizer<App> localizer)
    {
        _userClient = userClient;
        _localizer = localizer;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Assignments_Title"], null, true)
        ];
    }

    [Parameter, SupplyParameterFromQuery]
    public string? Tab { get; set; }

    protected override async Task OnInitializedAsync() =>
        _response = await _userClient.GetAssignmentsAsync();

    protected override void OnAfterRender(bool firstRender)
    {
        if (_tabs is not null && Tab is not null)
            _tabs.ActivatePanel(Tab);
    }

    private async Task ClaimDailyBonusAsync()
    {
        var response = await _userClient.ClaimDailyBonusAsync();
        _response = response
            .Map(bonus => _response.Unwrap() with
            {
                DailyBonus = bonus
            });
    }

    private async Task RejectDailyBonusAsync()
    {
        var response = await _userClient.RejectDailyBonusAsync();
        _response = response
            .Map(bonus => _response.Unwrap() with
            {
                DailyBonus = bonus
            });
    }

    private async Task StartDailyQuestsAsync()
    {
        var response = await _userClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Daily));
        _response = response
            .Map(assignments => _response.Unwrap() with
            {
                DailyAssignments = assignments
            });
    }

    private async Task CollectDailyQuestsAsync(string id)
    {
        var response = await _userClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Daily));

        _response = response
            .Map(x => _response.Unwrap() with
            {
                DailyAssignments = x
            });
    }

    private async Task StartWeeklyQuestsAsync()
    {
        var response = await _userClient.StartAssignmentsAsync(new StartAssignmentRequest(QuestType.Weekly));
        _response = response
            .Map(x => _response.Unwrap() with
            {
                WeeklyAssignments = x
            });
    }

    private async Task CollectWeeklyQuestsAsync(string id)
    {
        var response = await _userClient.ClaimAssignmentsAsync(id, new ClaimAssignmentRequest(QuestType.Weekly));
        _response = response
            .Map(assignments => _response.Unwrap() with
            {
                WeeklyAssignments = assignments
            });
    }
}
