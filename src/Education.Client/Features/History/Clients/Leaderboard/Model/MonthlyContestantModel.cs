namespace Education.Client.Features.History.Clients.Leaderboard.Model;

public sealed record MonthlyContestantModel(
    uint Rank,
    long Id,
    string FullName,
    string Image,
    uint Experience,
    Reward[] Rewards
);
