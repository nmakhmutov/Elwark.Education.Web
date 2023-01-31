using Education.Http;
using Education.Web.Client.Services.History.Leaderboard.Model;

namespace Education.Web.Client.Services.History.Leaderboard;

public interface IHistoryLeaderboardService
{
    Task<ApiResult<GlobalRankingModel[]>> GetGlobalAsync();

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null);
}
