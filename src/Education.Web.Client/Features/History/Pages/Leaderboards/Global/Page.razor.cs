using Education.Web.Client.Clients;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Clients.Leaderboard;
using Education.Web.Client.Features.History.Clients.Leaderboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Leaderboards.Global;

public sealed partial class Page
{
    private readonly string[] _regions = { "GL", "EU", "AS", "NA", "SA", "OC", "AF" };
    private long? _highlightUser;
    private string _region = "GL";
    private ApiResult<GlobalContestantModel[]> _result = ApiResult<GlobalContestantModel[]>.Loading();

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
        _result = await LeaderboardClient.GetGlobalAsync(_region);
    }

    private async Task OnRegionChanged(string region)
    {
        _region = region;
        _result = await LeaderboardClient.GetGlobalAsync(_region);
    }
}
