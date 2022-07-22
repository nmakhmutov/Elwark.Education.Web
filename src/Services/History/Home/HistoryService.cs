using Education.Web.Services.Api;
using Education.Web.Services.History.Home.Model;

namespace Education.Web.Services.History.Home;

internal sealed class HistoryService : IHistoryService
{
    private readonly ApiClient _api;

    public HistoryService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<HistoryOverviewModel>> GetAsync() =>
        _api.GetAsync<HistoryOverviewModel>("history");

    public Task<ApiResult<TopicOverviewModel[]>> SearchAsync(string query) =>
        _api.GetAsync<TopicOverviewModel[]>($"history/search?q={query}");
}
