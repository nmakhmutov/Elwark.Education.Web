using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Leaderboard;
using Education.Web.Client.Features.History.Services.Leaderboard.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Leaderboards.Global;

public sealed partial class Page
{
    private long? _highlightUser;
    private ApiResult<GlobalContestantModel[]> _result = ApiResult<GlobalContestantModel[]>.Loading();

    [Inject]
    private IHistoryLeaderboardService LeaderboardService { get; set; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private AuthenticationStateProvider StateProvider { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var state = await StateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
        _result = await LeaderboardService.GetGlobalAsync();
    }
}
