namespace Education.Web.Client.Services.History.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    DateOnly[] Months,
    MonthlyLeaderboardModel.LeaderboardModel Leaderboard,
    UserRankingModel? User,
    UserRankingModel[] Users
)
{
    public sealed record LeaderboardModel(DateOnly Month, DateTime StartsAt, DateTime EndsAt, bool IsActive);
}

