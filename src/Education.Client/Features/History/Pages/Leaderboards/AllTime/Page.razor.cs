using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Leaderboard;
using Education.Client.Features.History.Clients.Leaderboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Leaderboards.AllTime;

public sealed partial class Page: ComponentBase
{
    private readonly string[] _regions = ["GL", "EU", "AS", "NA", "SA", "OC", "AF"];
    private long? _highlightUser;
    private string _region = "GL";
    private ApiResult<ContestantModel[]> _result = ApiResult<ContestantModel[]>.Loading();

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
        _result = await LeaderboardClient.GetAllTimeAsync(_region);
    }

    private async Task OnRegionChanged(string region) =>
        _result = await LeaderboardClient.GetAllTimeAsync(_region = region);
}
