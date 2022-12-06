using Education.Web.Services.Api;

namespace Education.Web.Services.History.Search;

internal sealed class HistorySearchService : IHistorySearchService
{
    private readonly ApiClient _api;

    public HistorySearchService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<TopicOverviewModel[]>> SearchAsync(string query) =>
        _api.GetAsync<TopicOverviewModel[]>($"history/search?q={query}");
}
