using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Search.Model;
using Education.Web.Client.Features.History.Clients.Search.Request;

namespace Education.Web.Client.Features.History.Clients.Search;

internal sealed class HistorySearchService : IHistorySearchClient
{
    private readonly HistoryApiClient _api;

    public HistorySearchService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<SearchResultModel>> SearchAsync(SearchRequest request, CancellationToken ct) =>
        _api.PostAsync<SearchResultModel, SearchRequest>("history/search", request, ct);
}
