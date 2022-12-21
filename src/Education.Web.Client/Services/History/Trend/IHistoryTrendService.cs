using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Trend.Model;

namespace Education.Web.Client.Services.History.Trend;

internal interface IHistoryTrendService
{
    Task<ApiResult<HistoryOverviewModel>> GetAsync();
}