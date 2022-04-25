namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record UserRankingModel(uint Rank, long Id, string Name, string Image, uint Experience);
