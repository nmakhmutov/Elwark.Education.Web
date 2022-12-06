using Education.Web.Services.Api;
using Education.Web.Services.History.Trend.Model;

namespace Education.Web.Services.History.Trend;

internal interface IHistoryTrendService
{
    Task<ApiResult<HistoryOverviewModel>> GetAsync();
}