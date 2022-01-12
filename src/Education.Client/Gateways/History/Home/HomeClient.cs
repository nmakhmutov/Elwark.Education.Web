namespace Education.Client.Gateways.History.Home;

internal sealed class HomeClient : GatewayClient
{
    private readonly HttpClient _client;

    public HomeClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<HistoryOverview>> GetAsync() =>
        ExecuteAsync<HistoryOverview>(ct => _client.GetAsync("history", ct));

    public Task<ApiResponse<TopicSummary[]>> SearchAsync(string query) =>
        ExecuteAsync<TopicSummary[]>(ct => _client.GetAsync($"history/search?q={query}", ct));
}
