using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.History.Home;

internal sealed class HomeClient : GatewayClient
{
    private readonly HttpClient _client;

    public HomeClient(HttpClient client) =>
        _client = client;
        
    public Task<ApiResponse<HistoryOverview>> GetAsync() =>
        ExecuteAsync<HistoryOverview>(() => _client.GetAsync("history"));
        
    public Task<ApiResponse<TopicSummary[]>> SearchAsync(string query) =>
        ExecuteAsync<TopicSummary[]>(() => _client.GetAsync($"history/search?q={query}"));
}