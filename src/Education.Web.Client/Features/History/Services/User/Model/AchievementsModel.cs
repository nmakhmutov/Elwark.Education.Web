namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record AchievementsModel(uint Total, uint Completed, AchievementsModel.Category[] Categories)
{
    public sealed record Category(
        string Name,
        string Title,
        string Description,
        uint Total,
        uint Completed,
        Achievement[] Achievements
    );
}
