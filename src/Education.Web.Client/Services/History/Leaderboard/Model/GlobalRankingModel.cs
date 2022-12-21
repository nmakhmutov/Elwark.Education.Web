namespace Education.Web.Client.Services.History.Leaderboard.Model;

public sealed record GlobalRankingModel(uint Rank, long Id, string FullName, string Image, uint Level, ulong Experience);
