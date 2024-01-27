using Education.Client.Models;
using Education.Client.Models.Quest;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record MeOverviewModel(
    ulong TotalExaminations,
    ulong TotalQuizzes,
    ulong TotalDateGuessers,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet,
    MeOverviewModel.AssignmentModel Assignments,
    MeOverviewModel.AchievementModel Achievements
)
{
    public sealed record AchievementModel(
        uint Total,
        uint Unlocked,
        double Completeness,
        Achievement.CompletedModel? LatestCompletedAchievement
    );

    public sealed record AssignmentModel(QuestModel Daily, QuestModel Weekly);

    public sealed record QuestModel(QuestStatus Status, uint Completed, uint Total);
}
