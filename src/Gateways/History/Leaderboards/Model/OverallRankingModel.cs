namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record OverallRankingModel(uint Rank, long Id, string Name, string Image, uint Level, ulong Experience);
