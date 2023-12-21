namespace Education.Client.Features.History.Clients.Leaderboard.Model;

public sealed record MonthlyLeaderboardModel(
    bool IsActive,
    DateOnly Month,
    DateOnly[] Months,
    MonthlyContestantModel? Contestant,
    MonthlyContestantModel[] Contestants
);
