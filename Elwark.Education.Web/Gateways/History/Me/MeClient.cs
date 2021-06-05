using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.Statistics;

namespace Elwark.Education.Web.Gateways.History.Me
{
    internal sealed class MeClient : GatewayClient
    {
        private readonly HttpClient _client;

        public MeClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<HistoryUserProfile>> GetOverviewAsync() =>
            ExecuteAsync<HistoryUserProfile>(() => _client.GetAsync("history/me"));

        public Task<ApiResponse<UserStatistics>> GetStatisticsAsync() =>
            ExecuteAsync<UserStatistics>(() => _client.GetAsync("history/me/statistics"));
        
        public Task<ApiResponse<TestStatistics>> GetEasyTestStatisticsAsync() =>
            ExecuteAsync<TestStatistics>(() => _client.GetAsync("history/me/statistics/easy-tests"));
        
        public Task<ApiResponse<TestStatistics>> GetHardTestStatisticsAsync() =>
            ExecuteAsync<TestStatistics>(() => _client.GetAsync("history/me/statistics/hard-tests"));

        public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetFavoritesAsync(PageRequest request) =>
            ExecuteAsync<PageResponse<UserTopicSummary>>(() =>
                _client.GetAsync($"history/me/favorites?token={request.Token}&count={request.Count}"));

        public Task<ApiResponse<Unit>> CollectDailyReward() =>
            ExecuteAsync<Unit>(() => _client.PostAsync("history/me/reward/daily", EmptyContent));
    }
}
