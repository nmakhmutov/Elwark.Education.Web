using System.Text;
using Education.Web.Gateways.History.Leaderboards.Model;

namespace Education.Web.Gateways.History.Leaderboards;

internal sealed class LeaderboardClient : GatewayClient
{
    private readonly HttpClient _client;

    public LeaderboardClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<GlobalRankingModel[]>> GetGlobalAsync() =>
        ExecuteAsync<GlobalRankingModel[]>(ct => _client.GetAsync("history/leaderboards/global", ct));

    public Task<ApiResponse<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null)
    {
        var url = new StringBuilder("history/leaderboards/monthly");
        if (date.HasValue)
            url.Append('/').Append(date.Value.ToString("O"));

        return ExecuteAsync<MonthlyLeaderboardModel>(ct => _client.GetAsync(url.ToString(), ct));
    }
}
