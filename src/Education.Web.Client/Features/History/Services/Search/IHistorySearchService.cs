using Education.Web.Client.Features.History.Services.Search.Model;
using Education.Web.Client.Features.History.Services.Search.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Search;

internal interface IHistorySearchService
{
    Task<ApiResult<SearchResultModel>> SearchAsync(SearchRequest request, CancellationToken ct = default);
}
