namespace Education.Client.Features.History.Clients.Leaderboard.Model;

public sealed record ContestantModel(
    uint Rank,
    long Id,
    string FullName,
    string Image,
    ulong Experience
);
