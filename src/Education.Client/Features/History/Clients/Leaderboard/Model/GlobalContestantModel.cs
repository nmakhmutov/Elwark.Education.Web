namespace Education.Client.Features.History.Clients.Leaderboard.Model;

public sealed record GlobalContestantModel(
    uint Rank,
    long Id,
    string FullName,
    string Image,
    uint Level,
    ulong Experience
);
