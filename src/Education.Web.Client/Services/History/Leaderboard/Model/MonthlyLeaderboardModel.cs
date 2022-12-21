namespace Education.Web.Client.Services.History.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    MonthlyLeaderboardModel.LeaderboardModel Leaderboard,
    DateOnly[] Months,
    UserRankingModel? User,
    UserRankingModel[] Users
)
{
    public sealed record LeaderboardModel(DateOnly Month, DateTime StartsAt, DateTime EndsAt, bool IsActive);
}

