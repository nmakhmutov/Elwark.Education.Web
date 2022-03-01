using Education.Client.Gateways.History.Home.Model;

namespace Education.Client.Gateways.History.Home;

internal sealed class HomeClient : GatewayClient
{
    private readonly HttpClient _client;

    public HomeClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<HistoryOverviewModel>> GetAsync() =>
        ExecuteAsync<HistoryOverviewModel>(ct => _client.GetAsync("history", ct));

    public Task<ApiResponse<TopicOverviewModel[]>> SearchAsync(string query) =>
        ExecuteAsync<TopicOverviewModel[]>(ct => _client.GetAsync($"history/search?q={query}", ct));
}
