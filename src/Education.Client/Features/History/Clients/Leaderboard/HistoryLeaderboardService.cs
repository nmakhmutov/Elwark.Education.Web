using Education.Client.Clients;
using Education.Client.Features.History.Clients.Leaderboard.Model;

namespace Education.Client.Features.History.Clients.Leaderboard;

internal sealed class HistoryLeaderboardService : IHistoryLeaderboardClient
{
    private const string Root = "history/leaderboards";
    private readonly HistoryApiClient _api;

    public HistoryLeaderboardService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ContestantModel[]>> GetAllTimeAsync(string? region) =>
        _api.GetAsync<ContestantModel[]>($"{Root}/all-time/{region}");

    public Task<ApiResult<MonthlyLeaderboardModel>> GetMonthlyAsync(DateOnly? date)
    {
        var url = date.HasValue
            ? $"{Root}/monthly/{date.Value.ToString("O")}"
            : $"{Root}/monthly";

        return _api.GetAsync<MonthlyLeaderboardModel>(url);
    }
}
