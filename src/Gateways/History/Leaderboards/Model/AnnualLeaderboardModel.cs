namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record AnnualLeaderboardModel(int Year, UserRankingModel[] Users);
