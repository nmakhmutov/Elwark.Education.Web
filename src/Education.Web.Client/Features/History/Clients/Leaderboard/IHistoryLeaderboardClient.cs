using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Leaderboard.Model;

namespace Education.Web.Client.Features.History.Clients.Leaderboard;

public interface IHistoryLeaderboardClient
{
    Task<ApiResult<GlobalContestantModel[]>> GetGlobalAsync(string? region);

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null);
}
