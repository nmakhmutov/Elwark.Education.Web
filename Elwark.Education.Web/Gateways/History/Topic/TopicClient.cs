using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.Content;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    internal sealed class TopicClient : GatewayClient
    {
        private readonly HttpClient _client;

        public TopicClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetAsync(GetTopicsRequest request) =>
            ExecuteAsync<PageResponse<UserTopicSummary>>(() =>
                _client.GetAsync($"history/topics?epoch={request.Epoch}&count={request.Count}&token={request.Token}"));

        public Task<ApiResponse<TopicDetailComposition>> GetAsync(string id) =>
            ExecuteAsync<TopicDetailComposition>(() => _client.GetAsync($"history/topics/{id}"));

        public Task<ApiResponse<RandomTopic>> GetRandomAsync() =>
            ExecuteAsync<RandomTopic>(() => _client.GetAsync("history/topics/random"));

        public Task<ApiResponse<TestCreatedResult>> CreateTestAsync(string id, TestDifficulty difficulty) =>
            ExecuteAsync<TestCreatedResult>(() => _client.PostAsync($"history/topics/{id}/test?difficulty={difficulty}", EmptyContent));
        
        public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
            ExecuteAsync<bool>(() => _client.PostAsync($"history/topics/{id}/favorite", EmptyContent));

        public Task<ApiResponse<Unit>> LikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/like", EmptyContent));

        public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/dislike", EmptyContent));
    }
}
