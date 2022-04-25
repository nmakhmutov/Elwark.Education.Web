namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record MonthlyLeaderboardModel(DateOnly Month, UserRankingModel[] Users);
