namespace Education.Web.Client.Services.History.Leaderboard.Model;

public sealed record UserRankingModel(uint Rank, long Id, string FullName, string Image, uint Experience);
