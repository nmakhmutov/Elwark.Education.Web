namespace Education.Web.Client.Features.History.Services.Leaderboard.Model;

public sealed record UserRankingModel(uint Rank, long Id, string FullName, string Image, uint Experience);
