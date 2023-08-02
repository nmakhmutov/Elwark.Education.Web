namespace Education.Web.Client.Features.History.Services.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    bool IsActive,
    DateOnly Month,
    DateOnly[] Months,
    MonthlyContestantModel? Contestant,
    MonthlyContestantModel[] Contestants
);
