using Education.Http;

namespace Education.Web.Client.Services.History.Search;

internal interface IHistorySearchService
{
    Task<ApiResult<ArticleOverviewModel[]>> SearchAsync(string query);
}
