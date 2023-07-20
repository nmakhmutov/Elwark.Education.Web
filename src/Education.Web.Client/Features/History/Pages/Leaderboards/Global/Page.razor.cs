using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Pages.Leaderboards.Components;
using Education.Web.Client.Features.History.Services.Leaderboard;
using Education.Web.Client.Features.History.Services.Leaderboard.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Leaderboards.Global;

public sealed partial class Page
{
    private long _highlightUser;
    private ApiResult<GlobalRankingModel[]> _result = ApiResult<GlobalRankingModel[]>.Loading();

    [Inject]
    private IHistoryLeaderboardService LeaderboardService { get; set; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private AuthenticationStateProvider StateProvider { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _result = await LeaderboardService.GetGlobalAsync();

        var state = await StateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated ?? false)
            _highlightUser = state.User.GetId();
    }

    private RegularRanking.BackgroundColor GetBackgroundColor(long userId) =>
        _highlightUser == userId ? RegularRanking.BackgroundColor.Highlight : RegularRanking.BackgroundColor.Paper;

}
