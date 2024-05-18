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
    private long? _highlightUser;
    private ApiResult<MonthlyLeaderboardModel> _result = ApiResult<MonthlyLeaderboardModel>.Loading();

    [Inject]
    private IHistoryLeaderboardClient LeaderboardClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private AuthenticationStateProvider StateProvider { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery(Name = "month")]
    public DateOnly? Month { get; init; }

    protected override async Task OnInitializedAsync()
    {
        var state = await StateProvider.GetAuthenticationStateAsync();
        _highlightUser = state.User.GetIdOrDefault();
    }

    protected override async Task OnParametersSetAsync() =>
        _result = await LeaderboardClient.GetMonthlyAsync(Month);

    private void ChangeMonth(DateOnly month) =>
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter(nameof(month), month.ToString("O")));
}
