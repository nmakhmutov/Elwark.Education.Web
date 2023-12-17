using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Search.Model;
using Education.Web.Client.Features.History.Clients.Search.Request;

namespace Education.Web.Client.Features.History.Clients.Search;

internal interface IHistorySearchClient
{
    Task<ApiResult<SearchResultModel>> SearchAsync(SearchRequest request, CancellationToken ct = default);
}
