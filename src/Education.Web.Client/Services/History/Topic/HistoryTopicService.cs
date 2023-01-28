using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Topic.Model;
using Education.Web.Client.Services.History.Topic.Request;
using Education.Web.Client.Services.Model;

namespace Education.Web.Client.Services.History.Topic;

internal sealed class HistoryTopicService : IHistoryTopicService
{
    private readonly ApiClient _api;

    public HistoryTopicService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserTopicOverviewModel>>("history/topics", request);

    public Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request) =>
        _api.GetAsync<PagingOffsetModel<EmpireOverviewModel>>("history/empires", request);

    public Task<ApiResult<TopicCompositionModel>> GetAsync(string id) =>
        _api.GetAsync<TopicCompositionModel>($"history/topics/{id}");

    public Task<ApiResult<SpotlightModel>> GetSpotlightAsync() =>
        _api.GetAsync<SpotlightModel>("history/topics/spotlight");
    
    public Task<ApiResult<string>> GetRandomAsync(EpochType epoch) =>
        _api.GetAsync<string>($"history/topics/random?epoch={epoch.ToFastString()}");
}
