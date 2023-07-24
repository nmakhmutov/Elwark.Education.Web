using Education.Web.Client.Features.History.Services.Leaderboard.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Leaderboard;

internal sealed class HistoryLeaderboardService : IHistoryLeaderboardService
{
    private readonly HistoryApiClient _api;

    public HistoryLeaderboardService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<GlobalContestantModel[]>> GetGlobalAsync() =>
        _api.GetAsync<GlobalContestantModel[]>("history/leaderboards/global");

    public Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null) =>
        _api.GetAsync<MonthlyLeaderboardModel>(
            $"history/leaderboards/monthly{(date.HasValue ? $"/{date.Value.ToString("O")}" : "")}");
}
