using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record ProfileStatisticsModel(
    ulong TotalQuizzes,
    ulong TotalDateGuessers,
    ulong TotalExaminations,
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
