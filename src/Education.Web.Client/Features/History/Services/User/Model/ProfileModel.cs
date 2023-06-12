namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record ProfileModel(
    ProfileModel.LevelModel Level,
    ulong TotalQuizzes,
    ulong TotalEventGuessers,
    ProfileModel.AchievementModel Achievements,
    UserArticleOverviewModel[] RecentArticles
)
{
    public sealed record LevelModel(uint Rank, ulong Experience, ulong Threshold);

    public sealed record AchievementModel(
        uint Total,
        uint Unlocked,
        double Completeness,
        Achievement.CompletedModel? LatestCompletedAchievement
    );
}
