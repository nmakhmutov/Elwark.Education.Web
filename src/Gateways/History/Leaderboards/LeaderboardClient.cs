using Education.Web.Gateways.History.Leaderboards.Model;

namespace Education.Web.Gateways.History.Leaderboards;

internal sealed class LeaderboardClient : GatewayClient
{
    private readonly HttpClient _client;

    public LeaderboardClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<OverallRankingModel[]>> GetOverallAsync() =>
        ExecuteAsync<OverallRankingModel[]>(ct => _client.GetAsync("history/leaderboards/overall", ct));
    
    public Task<ApiResponse<MonthlyLeaderboardModel>> GetMonthlyAsync() =>
        ExecuteAsync<MonthlyLeaderboardModel>(ct => _client.GetAsync("history/leaderboards/monthly", ct));
    
    public Task<ApiResponse<AnnualLeaderboardModel>> GetAnnualAsync() =>
        ExecuteAsync<AnnualLeaderboardModel>(ct => _client.GetAsync("history/leaderboards/annual", ct));
}
