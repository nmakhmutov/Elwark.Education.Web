using Education.Client.Clients;
using Education.Client.Features.History.Clients.Search.Model;
using Education.Client.Features.History.Clients.Search.Request;

namespace Education.Client.Features.History.Clients.Search;

internal interface IHistorySearchClient
{
    Task<ApiResult<SearchResultModel>> SearchAsync(SearchRequest request, CancellationToken ct = default);
}
