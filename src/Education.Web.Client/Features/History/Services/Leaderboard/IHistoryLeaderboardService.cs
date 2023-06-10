using Education.Web.Client.Features.History.Services.Leaderboard.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Leaderboard;

public interface IHistoryLeaderboardService
{
    Task<ApiResult<GlobalRankingModel[]>> GetGlobalAsync();

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null);
}