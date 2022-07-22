using Education.Web.Services.Api;
using Education.Web.Services.History.Leaderboard.Model;

namespace Education.Web.Services.History.Leaderboard;

public interface IHistoryLeaderboardService
{
    Task<ApiResult<GlobalRankingModel[]>> GetGlobalAsync();

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null);
}
