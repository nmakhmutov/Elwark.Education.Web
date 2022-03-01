using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Users.Model;

public abstract record AchievementModel(string Category, string Name, string Title, string Description);

public sealed record CompletedAchievementModel(
    string Category,
    string Name,
    string Title,
    string Description,
    DateTime CompletedAt
) : AchievementModel(Category, Name, Title, Description);

public sealed record LadderAchievementModel(
    string Category,
    string Name,
    string Title,
    string Description,
    uint Level,
    uint Score,
    uint Goal,
    uint Completeness,
    IInternalMoney[] Rewards
) : AchievementModel(Category, Name, Title, Description);

public sealed record ProgressiveAchievementModel(
    string Category,
    string Name,
    string Title,
    string Description,
    uint Completeness,
    IInternalMoney[] Rewards
) : AchievementModel(Category, Name, Title, Description);
