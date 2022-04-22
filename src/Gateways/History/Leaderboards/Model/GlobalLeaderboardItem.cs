namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record GlobalLeaderboardItem(
    long Id,
    string Name,
    string Image,
    uint Level,
    ulong Experience,
    uint Position
);
