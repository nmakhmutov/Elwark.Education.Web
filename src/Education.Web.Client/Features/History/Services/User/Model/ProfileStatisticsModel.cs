using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record ProfileStatisticsModel(
    ulong TotalQuizzes,
    ulong TotalDateGuessers,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet,
    ProfileStatisticsModel.AchievementModel Achievements
)
{
    public sealed record AchievementModel(
        uint Total,
        uint Unlocked,
        double Completeness,
        Achievement.CompletedModel? LatestCompletedAchievement
    );
}
