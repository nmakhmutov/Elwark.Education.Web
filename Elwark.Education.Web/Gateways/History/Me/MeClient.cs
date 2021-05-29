using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models;

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

        public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetFavoritesAsync(PageRequest request) =>
            ExecuteAsync<PageResponse<UserTopicSummary>>(() =>
                _client.GetAsync($"history/me/favorites?token={request.Token}&count={request.Count}"));
    }
}
