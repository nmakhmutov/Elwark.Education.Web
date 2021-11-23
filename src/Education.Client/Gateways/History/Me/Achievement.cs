using System;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public abstract record Achievement(string Name, string Title, string Description);

public sealed record CompletedAchievement(string Name, string Title, string Description, DateTime CompletedAt)
    : Achievement(Name, Title, Description);

public sealed record ProgressiveAchievement(
    string Name,
    string Title,
    string Description,
    uint Completeness,
    IGameCurrency[] Rewards
) : Achievement(Name, Title, Description);

public sealed record LadderAchievement(
    string Name,
    string Title,
    string Description,
    uint Level,
    uint Score,
    uint Goal,
    uint Completeness,
    IGameCurrency[] Rewards
) : Achievement(Name, Title, Description);
