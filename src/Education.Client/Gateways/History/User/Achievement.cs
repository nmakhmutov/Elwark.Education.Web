using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.User;

public abstract record Achievement(string Id, string Title, string Description);

public sealed record CompletedAchievement(string Id, string Title, string Description, DateTime CompletedAt)
    : Achievement(Id, Title, Description);

public sealed record ProgressiveAchievement(
    string Id,
    string Title,
    string Description,
    uint Completeness,
    IVirtualCurrency[] Rewards
) : Achievement(Id, Title, Description);

public sealed record LadderAchievement(
    string Id,
    string Title,
    string Description,
    uint Level,
    uint Score,
    uint Goal,
    uint Completeness,
    IVirtualCurrency[] Rewards
) : Achievement(Id, Title, Description);
