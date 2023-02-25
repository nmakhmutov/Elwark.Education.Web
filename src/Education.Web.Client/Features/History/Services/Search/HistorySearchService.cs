using Education.Web.Client.Features.History.Services.Search.Model;
using Education.Web.Client.Features.History.Services.Search.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Search;

internal sealed class HistorySearchService : IHistorySearchService
{
    private readonly HistoryApiClient _api;

    public HistorySearchService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<SearchResultModel>> SearchAsync(SearchRequest request, CancellationToken ct) =>
        _api.PostAsync<SearchResultModel, SearchRequest>("history/search", request, ct);
}
