using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.Leaderboard.Model;

public sealed record MonthlyContestantModel(
    uint Rank,
    long Id,
    string FullName,
    string Image,
    uint Experience,
    InternalMoneyModel[] Rewards
);
