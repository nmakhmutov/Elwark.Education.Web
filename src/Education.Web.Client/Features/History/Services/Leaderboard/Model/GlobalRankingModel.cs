namespace Education.Web.Client.Features.History.Services.Leaderboard.Model;

public sealed record GlobalRankingModel(
    uint Rank,
    long Id,
    string FullName,
    string Image,
    uint Level,
    ulong Experience
);