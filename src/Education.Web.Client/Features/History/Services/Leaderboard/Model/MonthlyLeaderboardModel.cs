namespace Education.Web.Client.Features.History.Services.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    MonthlyContestantModel? User,
    DateOnly Month,
    DateTime StartsAt,
    DateTime EndsAt,
    bool IsActive,
    DateOnly[] Months,
    MonthlyContestantModel[] Users
);
