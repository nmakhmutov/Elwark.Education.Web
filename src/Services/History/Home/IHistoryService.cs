using Education.Web.Services.Api;
using Education.Web.Services.History.Home.Model;

namespace Education.Web.Services.History.Home;

internal interface IHistoryService
{
    Task<ApiResult<HistoryOverviewModel>> GetAsync();
    
    Task<ApiResult<TopicOverviewModel[]>> SearchAsync(string query);
}