using Education.Web.Client.Clients;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Clients.Leaderboard;
using Education.Web.Client.Features.History.Clients.Leaderboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Leaderboards.Monthly;

public sealed partial class Page
{
    private long? _highlightUser;
    private ApiResult<MonthlyLeaderboardModel> _result = ApiResult<MonthlyLeaderboardModel>.Loading();

    [Inject]
    private IHistoryLeaderboardClient LeaderboardClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private AuthenticationStateProvider StateProvider { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var state = await StateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
        _result = await LeaderboardClient.GetMonthAsync();
    }

    private async Task OnMonthChanged(DateOnly month) =>
        _result = await LeaderboardClient.GetMonthAsync(month);
}
