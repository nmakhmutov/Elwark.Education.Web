using Education.Web.Gateways.History.Leaderboards.Model;

namespace Education.Web.Gateways.History.Leaderboards;

internal sealed class LeaderboardClient : GatewayClient
{
    private readonly HttpClient _client;

    public LeaderboardClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<GlobalRankingModel[]>> GetGlobalAsync() =>
        ExecuteAsync<GlobalRankingModel[]>(ct => _client.GetAsync("history/leaderboards/global", ct));
    
    public Task<ApiResponse<AnnualLeaderboardModel>> GetCurrentYearAsync() =>
        ExecuteAsync<AnnualLeaderboardModel>(ct => _client.GetAsync("history/leaderboards/current/year", ct));

    public Task<ApiResponse<MonthlyLeaderboardModel>> GetCurrentMonthAsync() =>
        ExecuteAsync<MonthlyLeaderboardModel>(ct => _client.GetAsync("history/leaderboards/current/month", ct));
}
