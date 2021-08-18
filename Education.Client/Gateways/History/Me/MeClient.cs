using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.Me
{
    internal sealed class MeClient : GatewayClient
    {
        private readonly HttpClient _client;

        public MeClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<HistoryUserProfile>> GetOverviewAsync() =>
            ExecuteAsync<HistoryUserProfile>(() => _client.GetAsync("history/me"));

        public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetFavoritesAsync(PageRequest request) =>
            ExecuteAsync<PageResponse<UserTopicSummary>>(() =>
                _client.GetAsync($"history/me/favorites?page={request.Page}&count={request.Count}"));

        public Task<ApiResponse<Unit>> CollectDailyReward() =>
            ExecuteAsync<Unit>(() => _client.PostAsync("history/me/reward/daily", EmptyContent));
        
        public Task<ApiResponse<HistoryUserRestriction>> GetRestrictions() =>
            ExecuteAsync<HistoryUserRestriction>(() => _client.GetAsync("history/me/restrictions"));
        
        public Task<ApiResponse<TopicTestStatistics>> GetEasyTestStatisticsAsync() =>
            ExecuteAsync<TopicTestStatistics>(() => _client.GetAsync("history/me/statistics/easy-tests"));
        
        public Task<ApiResponse<TopicTestStatistics>> GetHardTestStatisticsAsync() =>
            ExecuteAsync<TopicTestStatistics>(() => _client.GetAsync("history/me/statistics/hard-tests"));
        
        public Task<ApiResponse<MixedTestStatistics>> GetMixedTestStatisticsAsync() =>
            ExecuteAsync<MixedTestStatistics>(() => _client.GetAsync("history/me/statistics/mixed-tests"));
        
        public Task<ApiResponse<TopicStatistics>> GetTopicStatisticsAsync(string topicId) =>
            ExecuteAsync<TopicStatistics>(() => _client.GetAsync($"history/me/statistics/topic/{topicId}"));
    }
}
