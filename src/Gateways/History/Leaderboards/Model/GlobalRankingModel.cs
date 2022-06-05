namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record GlobalRankingModel(uint Rank, long Id, string FullName, string Image, uint Level, ulong Experience);
