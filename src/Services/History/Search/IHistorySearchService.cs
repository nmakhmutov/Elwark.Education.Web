using Education.Web.Services.Api;

namespace Education.Web.Services.History.Search;

internal interface IHistorySearchService
{
    Task<ApiResult<TopicOverviewModel[]>> SearchAsync(string query);
}