using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.Me;

internal sealed class MeClient : GatewayClient
{
    private readonly HttpClient _client;

    public MeClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<HistoryUserProfile>> GetOverviewAsync() =>
        ExecuteAsync<HistoryUserProfile>(ct => _client.GetAsync("history/me", ct));

    public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetFavoritesAsync(PageRequest request) =>
        ExecuteAsync<PageResponse<UserTopicSummary>>(ct => _client.GetAsync($"history/me/favorites{request.ToQuery()}", ct));

    public Task<ApiResponse<Unit>> CollectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.PostAsync("history/me/rewards/daily", EmptyContent, ct));

    public Task<ApiResponse<TopicTestStatistics>> GetEasyTestStatisticsAsync() =>
        ExecuteAsync<TopicTestStatistics>(ct => _client.GetAsync("history/me/tests/easy", ct));

    public Task<ApiResponse<TopicTestStatistics>> GetHardTestStatisticsAsync() =>
        ExecuteAsync<TopicTestStatistics>(ct => _client.GetAsync("history/me/tests/hard", ct));

    public Task<ApiResponse<MixedTestStatistics>> GetMixedTestStatisticsAsync() =>
        ExecuteAsync<MixedTestStatistics>(ct => _client.GetAsync("history/me/tests/mixed", ct));

    public Task<ApiResponse<EventGuesserStatistics>> GetEventGuesserStatisticsAsync() =>
        ExecuteAsync<EventGuesserStatistics>(ct => _client.GetAsync("history/me/event-guessers", ct));

    public Task<ApiResponse<TopicStatistics>> GetTopicStatisticsAsync(string topicId) =>
        ExecuteAsync<TopicStatistics>(ct => _client.GetAsync($"history/me/topics/{topicId}", ct));
}
