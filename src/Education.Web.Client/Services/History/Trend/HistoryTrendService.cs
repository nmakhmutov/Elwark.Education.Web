using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Trend.Model;

namespace Education.Web.Client.Services.History.Trend;

internal sealed class HistoryTrendService : IHistoryTrendService
{
    private readonly ApiClient _api;

    public HistoryTrendService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<HistoryOverviewModel>> GetAsync() =>
        _api.GetAsync<HistoryOverviewModel>("history/trends");
}
