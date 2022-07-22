using Education.Web.Services.Api;
using Education.Web.Services.History.Topic.Model;
using Education.Web.Services.History.Topic.Request;
using Education.Web.Services.Model;

namespace Education.Web.Services.History.Topic;

public interface IHistoryTopicService
{
    Task<ApiResult<PagingOffsetModel<UserTopicOverviewModel>>> GetAsync(GetTopicsRequest request);

    Task<ApiResult<PagingOffsetModel<EmpireOverview>>> GetAsync(GetEmpiresRequest request);

    Task<ApiResult<TopicDetailCompositionModel>> GetAsync(string id);

    Task<ApiResult<string>> GetRandomAsync(EpochType epoch);

    Task<ApiResult<bool>> ToggleFavoriteAsync(string id);

    Task<ApiResult<Unit>> LikeAsync(string id);

    Task<ApiResult<Unit>> DislikeAsync(string id);
}
