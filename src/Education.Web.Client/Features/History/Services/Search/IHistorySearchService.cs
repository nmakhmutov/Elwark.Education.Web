using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Search;

internal interface IHistorySearchService
{
    Task<ApiResult<ArticleOverviewModel[]>> SearchAsync(string query);
}
