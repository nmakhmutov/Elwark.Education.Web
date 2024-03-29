namespace Education.Client.Features.History.Clients.User.Model;

public sealed record AchievementsModel(uint Total, uint Unlocked, AchievementsModel.Category[] Categories)
{
    public sealed record Category(
        string Title,
        string Description,
        uint Total,
        uint Unlocked,
        Achievement[] Achievements
    );
}
