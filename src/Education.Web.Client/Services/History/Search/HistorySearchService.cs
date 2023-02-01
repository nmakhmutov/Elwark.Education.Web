using Education.Web.Client.Services.Api;

namespace Education.Web.Client.Services.History.Search;

internal sealed class HistorySearchService : IHistorySearchService
{
    private readonly ApiClient _api;

    public HistorySearchService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<ArticleOverviewModel[]>> SearchAsync(string query) =>
        _api.GetAsync<ArticleOverviewModel[]>($"history/search?q={query}");
}
