using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Leaderboard;
using Education.Client.Features.History.Clients.Leaderboard.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Leaderboards;

public sealed partial class AllTimePage : ComponentBase
{
    private static readonly string[] Regions = ["GL", "AF", "AS", "EU", "NA", "SA", "OC"];
    private long? _highlightUser;
    private ApiResult<ContestantModel[]> _response = ApiResult<ContestantModel[]>.Loading();

    [Inject]
    private IHistoryLeaderboardClient LeaderboardClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private AuthenticationStateProvider StateProvider { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery]
    public string? Region { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var state = await StateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
    }

    protected override async Task OnParametersSetAsync()
    {
        var region = Region?.ToUpper();
        Region = Regions.Contains(region) ? region : Regions[0];
        _response = await LeaderboardClient.GetAllTimeAsync(Region);
    }

    private void ChangeRegion(string? region)
    {
        if (string.IsNullOrEmpty(region))
            return;

        if (region.Equals(Region, StringComparison.OrdinalIgnoreCase))
            return;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter(nameof(Region).ToLower(), region));
    }
}
