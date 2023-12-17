using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Leaderboard.Model;

namespace Education.Web.Client.Features.History.Clients.Leaderboard;

internal sealed class HistoryLeaderboardService : IHistoryLeaderboardClient
{
    private readonly HistoryApiClient _api;

    public HistoryLeaderboardService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<GlobalContestantModel[]>> GetGlobalAsync(string? region) =>
        _api.GetAsync<GlobalContestantModel[]>($"history/leaderboards/global/{region}");

    public Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null) =>
        _api.GetAsync<MonthlyLeaderboardModel>(
            $"history/leaderboards/monthly{(date.HasValue ? $"/{date.Value.ToString("O")}" : "")}");
}
