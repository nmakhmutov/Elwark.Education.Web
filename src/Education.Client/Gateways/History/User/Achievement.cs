using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.User;

public abstract record Achievement(string Category, string Name, string Title, string Description);

public sealed record CompletedAchievement(
    string Category,
    string Name,
    string Title,
    string Description,
    DateTime CompletedAt
) : Achievement(Category, Name, Title, Description);

public sealed record LadderAchievement(
    string Category,
    string Name,
    string Title,
    string Description,
    uint Level,
    uint Score,
    uint Goal,
    uint Completeness,
    IInternalMoney[] Rewards
) : Achievement(Category, Name, Title, Description);
