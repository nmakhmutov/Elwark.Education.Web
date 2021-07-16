using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Topic
{
    internal sealed class TopicClient : GatewayClient
    {
        private readonly HttpClient _client;

        public TopicClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetAsync(GetTopicsRequest request) =>
            ExecuteAsync<PageResponse<UserTopicSummary>>(() =>
                _client.GetAsync($"history/topics?epoch={request.Epoch}&count={request.Count}&page={request.Page}"));

        public Task<ApiResponse<TopicDetailComposition>> GetAsync(string id) =>
            ExecuteAsync<TopicDetailComposition>(() => _client.GetAsync($"history/topics/{id}"));

        public Task<ApiResponse<RandomTopic>> GetRandomAsync() =>
            ExecuteAsync<RandomTopic>(() => _client.GetAsync("history/topics/random"));

        public Task<ApiResponse<TestCreatedResult>> CreateEasyTestAsync(string id) =>
            ExecuteAsync<TestCreatedResult>(() => _client.PostAsync($"history/topics/{id}/test/easy", EmptyContent));
        
        public Task<ApiResponse<TestCreatedResult>> CreateHardTestAsync(string id) =>
            ExecuteAsync<TestCreatedResult>(() => _client.PostAsync($"history/topics/{id}/test/hard", EmptyContent));
        
        public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
            ExecuteAsync<bool>(() => _client.PostAsync($"history/topics/{id}/favorite", EmptyContent));

        public Task<ApiResponse<Unit>> LikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/like", EmptyContent));

        public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
            ExecuteAsync<Unit>(() => _client.PostAsync($"history/topics/{id}/dislike", EmptyContent));
    }
}
