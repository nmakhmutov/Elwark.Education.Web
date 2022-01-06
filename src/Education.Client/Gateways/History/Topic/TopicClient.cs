using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Topic;

internal sealed class TopicClient : GatewayClient
{
    private readonly HttpClient _client;

    public TopicClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetAsync(GetTopicsRequest request) =>
        ExecuteAsync<PageResponse<UserTopicSummary>>(ct => _client.GetAsync($"history/topics{request.ToQuery()}", ct));
    
    public Task<ApiResponse<PageResponse<EmpireSummary>>> GetAsync(GetEmpiresRequest request) =>
        ExecuteAsync<PageResponse<EmpireSummary>>(ct => _client.GetAsync($"history/empires{request.ToQuery()}", ct));

    public Task<ApiResponse<TopicDetailComposition>> GetAsync(string id) =>
        ExecuteAsync<TopicDetailComposition>(ct => _client.GetAsync($"history/topics/{id}", ct));

    public Task<ApiResponse<RandomTopic>> GetRandomAsync() =>
        ExecuteAsync<RandomTopic>(ct => _client.GetAsync("history/topics/random", ct));

    public Task<ApiResponse<TestCreatedResult>> CreateEasyTestAsync(string id) =>
        ExecuteAsync<TestCreatedResult>(ct => _client.PostAsync($"history/topics/{id}/tests/easy", EmptyContent, ct));
        
    public Task<ApiResponse<TestCreatedResult>> CreateHardTestAsync(string id) =>
        ExecuteAsync<TestCreatedResult>(ct => _client.PostAsync($"history/topics/{id}/tests/hard", EmptyContent, ct));
        
    public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
        ExecuteAsync<bool>(ct => _client.PostAsync($"history/topics/{id}/favorites", EmptyContent, ct));

    public Task<ApiResponse<Unit>> LikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/likes", EmptyContent, ct));

    public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/dislikes", EmptyContent, ct));
}
