using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Topic.Model;
using Education.Web.Client.Services.History.Topic.Request;
using Education.Web.Client.Services.Model;

namespace Education.Web.Client.Services.History.Topic;

public interface IHistoryTopicService
{
    Task<ApiResult<PagingOffsetModel<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request);

    Task<ApiResult<PagingOffsetModel<EmpireOverviewModel>>> GetAsync(GetEmpiresRequest request);

    Task<ApiResult<TopicCompositionModel>> GetAsync(string id);

    Task<ApiResult<SpotlightModel>> GetSpotlightAsync();
    
    Task<ApiResult<string>> GetRandomAsync(EpochType epoch);
}
