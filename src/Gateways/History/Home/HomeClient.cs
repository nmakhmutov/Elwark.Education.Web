using Education.Web.Gateways.History.Home.Model;

namespace Education.Web.Gateways.History.Home;

internal sealed class HomeClient : GatewayClient
{
    private readonly HttpClient _client;

    public HomeClient(HttpClient client) =>
        _client = client;

    public Task<ApiResult<HistoryOverviewModel>> GetAsync() =>
        ExecuteAsync<HistoryOverviewModel>(ct => _client.GetAsync("history", ct));

    public Task<ApiResult<TopicOverviewModel[]>> SearchAsync(string query) =>
        ExecuteAsync<TopicOverviewModel[]>(ct => _client.GetAsync($"history/search?q={query}", ct));
}
