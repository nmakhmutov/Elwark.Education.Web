using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record AnnualLeaderboardModel(RangeModel<DateTime> Range, UserRankingModel[] Users);
