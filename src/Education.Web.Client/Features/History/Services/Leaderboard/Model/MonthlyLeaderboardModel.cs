namespace Education.Web.Client.Features.History.Services.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    UserRankingModel? User,
    DateOnly Month,
    DateTime StartsAt,
    DateTime EndsAt,
    bool IsActive,
    DateOnly[] Months,
    UserRankingModel[] Users
);
