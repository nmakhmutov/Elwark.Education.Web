namespace Education.Web.Gateways.History.Users.Model;

public sealed record AchievementsDetailModel(
    uint Total,
    uint Completed,
    AchievementsDetailModel.Category[] Categories
)
{
    public sealed record Category(
        string Name,
        string Title,
        string Description,
        uint Total,
        uint Completed,
        AchievementModel[] Achievements
    );
}
