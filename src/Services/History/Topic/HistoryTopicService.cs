using Education.Web.Services.Api;
using Education.Web.Services.History.Topic.Model;
using Education.Web.Services.History.Topic.Request;
using Education.Web.Services.Model;

namespace Education.Web.Services.History.Topic;

internal sealed class HistoryTopicService : IHistoryTopicService
{
    private readonly ApiClient _api;

    public HistoryTopicService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<OffsetResponse<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request) =>
        _api.GetAsync<OffsetResponse<UserTopicOverviewModel>>($"history/topics{request.ToQueryString()}");

    public Task<ApiResult<OffsetResponse<EmpireOverview>>> GetAsync(GetEmpiresRequest request) =>
        _api.GetAsync<OffsetResponse<EmpireOverview>>($"history/empires{request.ToQueryString()}");

    public Task<ApiResult<TopicDetailCompositionModel>> GetAsync(string id) =>
        _api.GetAsync<TopicDetailCompositionModel>($"history/topics/{id}");


    public Task<ApiResult<string>> GetRandomAsync(EpochType epoch) =>
        _api.GetAsync<string>($"history/topics/random?epoch={epoch.ToFastString()}");

    public Task<ApiResult<bool>> ToggleFavoriteAsync(string id) =>
        _api.PostAsync<bool>($"history/topics/{id}/favorites");

    public Task<ApiResult<Unit>> LikeAsync(string id) =>
        _api.PostAsync<Unit>($"history/topics/{id}/likes");

    public Task<ApiResult<Unit>> DislikeAsync(string id) =>
        _api.PostAsync<Unit>($"history/topics/{id}/dislikes");
}
