using Education.Http;

namespace Education.Web.Client.Services.History.Search;

internal sealed class HistorySearchService : IHistorySearchService
{
    private readonly HistoryApiClient _api;

    public HistorySearchService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ArticleOverviewModel[]>> SearchAsync(string query) =>
        _api.GetAsync<ArticleOverviewModel[]>($"history/search?q={query}");
}
