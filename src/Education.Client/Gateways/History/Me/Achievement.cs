using System;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public abstract record Achievement(string Name, string Title, string Description);

public sealed record CompletedAchievement(string Name, string Title, string Description, DateTime CompletedAt)
    : Achievement(Name, Title, Description);

public sealed record LadderAchievement(
    string Name,
    string Title,
    string Description,
    uint Level,
    uint Score,
    uint Goal,
    uint Progress,
    Reward Reward
) : Achievement(Name, Title, Description);
