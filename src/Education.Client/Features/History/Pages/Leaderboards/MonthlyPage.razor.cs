using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Leaderboard;
using Education.Client.Features.History.Clients.Leaderboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Leaderboards;

public sealed partial class MonthlyPage : ComponentBase
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryLeaderboardClient _leaderboardClient;
    private readonly NavigationManager _navigation;
    private readonly AuthenticationStateProvider _stateProvider;
    private long? _highlightUser;
    private ApiResult<MonthlyLeaderboardModel> _response = ApiResult<MonthlyLeaderboardModel>.Loading();

    public MonthlyPage(IStringLocalizer<App> localizer, IHistoryLeaderboardClient leaderboardClient,
        NavigationManager navigation, AuthenticationStateProvider stateProvider)
    {
        _localizer = localizer;
        _leaderboardClient = leaderboardClient;
        _navigation = navigation;
        _stateProvider = stateProvider;
    }

    [SupplyParameterFromQuery(Name = "month")]
    public DateOnly? Month { get; init; }

    protected override async Task OnInitializedAsync()
    {
        var state = await _stateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
    }

    protected override async Task OnParametersSetAsync() =>
        _response = await _leaderboardClient.GetMonthlyAsync(Month);

    private void ChangeMonth(DateOnly month) =>
        _navigation.NavigateTo(HistoryUrl.Leaderboard.Monthly(month));
}
