using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.History.Leaderboards.Model;

public sealed record MonthlyLeaderboardModel(RangeModel<DateTime> Range, UserRankingModel[] Users);
