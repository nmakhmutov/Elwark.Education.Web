using Education.Web.Gateways.History.Leaderboards.Model;

namespace Education.Web.Gateways.History.Leaderboards;

internal sealed class LeaderboardClient : GatewayClient
{
    private readonly HttpClient _client;

    public LeaderboardClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<GlobalLeaderboardItem[]>> GetGlobalLeaderboardAsync() =>
        ExecuteAsync<GlobalLeaderboardItem[]>(ct => _client.GetAsync("history/leaderboards/global", ct));
}
