namespace Education.Client.Features.History.Clients.User.Model;

public sealed record MeOverviewModel(
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<GameCurrency, long> Wallet,
    MeOverviewModel.MonthlyPerformanceModel MonthlyPerformance,
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

    public sealed record QuestModel(uint Completed, uint Total);

    public sealed record MonthlyPerformanceModel(uint BestExperience, uint UserExperience, uint UserRank);
}
