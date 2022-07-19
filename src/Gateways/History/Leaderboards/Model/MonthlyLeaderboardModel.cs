namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record MonthlyLeaderboardModel(
    MonthlyLeaderboardModel.LeaderboardModel Leaderboard,
    DateOnly[] Months,
    UserRankingModel? User,
    UserRankingModel[] Users
)
{
    public sealed record LeaderboardModel(DateOnly Month, DateTime StartsAt, DateTime EndsAt, bool IsActive);
}

