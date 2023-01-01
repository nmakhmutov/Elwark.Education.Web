namespace Education.Web.Client.Services.History.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    UserRankingModel? User,
    DateOnly Month,
    DateTime StartsAt,
    DateTime EndsAt,
    bool IsActive,
    DateOnly[] Months,
    UserRankingModel[] Users
);
