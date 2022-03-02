using Education.Web.Gateways.History.Topics.Model;
using Education.Web.Gateways.History.Topics.Request;
using Education.Web.Gateways.Models;
using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.History.Topics;

internal sealed class TopicClient : GatewayClient
{
    private readonly HttpClient _client;

    public TopicClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<PageResponse<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request) =>
        ExecuteAsync<PageResponse<UserTopicOverviewModel>>(ct => _client.GetAsync($"history/topics{request.ToQuery()}", ct));

    public Task<ApiResponse<TopicDetailCompositionModel>> GetAsync(string id) =>
        ExecuteAsync<TopicDetailCompositionModel>(ct => _client.GetAsync($"history/topics/{id}", ct));

    public Task<ApiResponse<RandomTopicIdModel>> GetRandomAsync(EpochType epoch) =>
        ExecuteAsync<RandomTopicIdModel>(ct => _client.GetAsync($"history/topics/random?epoch={epoch}", ct));

    public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
        ExecuteAsync<bool>(ct => _client.PostAsync($"history/topics/{id}/favorites", EmptyContent, ct));

    public Task<ApiResponse<Unit>> LikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/likes", EmptyContent, ct));

    public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/dislikes", EmptyContent, ct));
}
