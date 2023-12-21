using Education.Client.Clients;
using Education.Client.Features.History.Clients.Leaderboard.Model;

namespace Education.Client.Features.History.Clients.Leaderboard;

public interface IHistoryLeaderboardClient
{
    Task<ApiResult<GlobalContestantModel[]>> GetGlobalAsync(string? region);

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthAsync(DateOnly? date = null);
}
