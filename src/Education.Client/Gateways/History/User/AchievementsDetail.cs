namespace Education.Client.Gateways.History.User;

public sealed record AchievementsDetail(
    uint Total,
    uint Completed,
    IEnumerable<AchievementsDetail.Category> Categories
)
{
    public sealed record Category(
        string Name,
        string Title,
        string Description,
        uint Total,
        uint Completed,
        IEnumerable<Achievement> Achievements
    );
}
