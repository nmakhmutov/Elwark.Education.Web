namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record MonthlyLeaderboardModel(
    DateTime StartsAt,
    DateTime EndsAt,
    DateOnly Leaderboard,
    DateOnly[] Leaderboards,
    UserRankingModel[] Users
);
