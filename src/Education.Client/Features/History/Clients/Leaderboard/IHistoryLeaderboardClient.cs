using Education.Client.Clients;
using Education.Client.Features.History.Clients.Leaderboard.Model;

namespace Education.Client.Features.History.Clients.Leaderboard;

public interface IHistoryLeaderboardClient
{
    Task<ApiResult<ContestantModel[]>> GetAllTimeAsync(string? region);

    Task<ApiResult<MonthlyLeaderboardModel>> GetMonthlyAsync(DateOnly? date);
}
