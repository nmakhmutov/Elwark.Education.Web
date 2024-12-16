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

    private readonly IHistoryLeaderboardClient _leaderboardClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly AuthenticationStateProvider _stateProvider;

    private long? _highlightUser;
    private ApiResult<ContestantModel[]> _response = ApiResult<ContestantModel[]>.Loading();

    public AllTimePage(IHistoryLeaderboardClient leaderboardClient, IStringLocalizer<App> localizer,
        AuthenticationStateProvider stateProvider, NavigationManager navigation)
    {
        _leaderboardClient = leaderboardClient;
        _localizer = localizer;
        _stateProvider = stateProvider;
        _navigation = navigation;
    }

    [SupplyParameterFromQuery]
    public string? Region { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var state = await _stateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
    }

    protected override async Task OnParametersSetAsync()
    {
        var region = Region?.ToUpper();
        Region = Regions.Contains(region) ? region : Regions[0];
        _response = await _leaderboardClient.GetAllTimeAsync(Region);
    }

    private void ChangeRegion(string? region)
    {
        if (string.IsNullOrEmpty(region))
            return;

        if (region.Equals(Region, StringComparison.OrdinalIgnoreCase))
            return;

        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter(nameof(Region).ToLower(), region));
    }
}
