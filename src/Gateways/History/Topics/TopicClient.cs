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

    public Task<ApiResponse<OffsetResponse<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request)
    {
        var url = $"history/topics{request.ToQueryString()}";
        return ExecuteAsync<OffsetResponse<UserTopicOverviewModel>>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResponse<TopicDetailCompositionModel>> GetAsync(string id) =>
        ExecuteAsync<TopicDetailCompositionModel>(ct => _client.GetAsync($"history/topics/{id}", ct));

    public Task<ApiResponse<RandomTopicIdModel>> GetRandomAsync(EpochType epoch)
    {
        var url = $"history/topics/random?epoch={epoch.ToFastString()}";
        return ExecuteAsync<RandomTopicIdModel>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResponse<bool>> ToggleFavoriteAsync(string id) =>
        ExecuteAsync<bool>(ct => _client.PostAsync($"history/topics/{id}/favorites", null, ct));

    public Task<ApiResponse<Unit>> LikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/likes", null, ct));

    public Task<ApiResponse<Unit>> DislikeAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.PostAsync($"history/topics/{id}/dislikes", null, ct));
}
