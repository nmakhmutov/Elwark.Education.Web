using Education.Web.Services.Api;
using Education.Web.Services.History.Trend.Model;

namespace Education.Web.Services.History.Trend;

internal sealed class HistoryTrendService : IHistoryTrendService
{
    private readonly ApiClient _api;

    public HistoryTrendService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<HistoryOverviewModel>> GetAsync() =>
        _api.GetAsync<HistoryOverviewModel>("history/trends");
}
