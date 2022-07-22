using Education.Web.Services.Api;
using Education.Web.Services.History.Leaderboard.Model;

namespace Education.Web.Services.History.Leaderboard;

internal sealed class HistoryLeaderboardService : IHistoryLeaderboardService
{
    private readonly ApiClient _api;

    public HistoryLeaderboardService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<GlobalRankingModel[]>> GetGlobalAsync() =>
        _api.GetAsync<GlobalRankingModel[]>("history/leaderboards/global");

    public Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null) =>
        _api.GetAsync<MonthlyLeaderboardModel>(
            $"history/leaderboards/monthly{(date.HasValue ? $"/{date.Value.ToString("O")}" : "")}");
}
