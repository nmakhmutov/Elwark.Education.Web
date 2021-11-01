using System;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public abstract record Achievement(string Name, uint Progress, DateTime? CompletedAt, Reward Reward);

public sealed record CommonAchievement(string Name, uint Progress, DateTime? CompletedAt, Reward Reward)
    : Achievement(Name, Progress, CompletedAt, Reward);

public sealed record LeveledAchievement(
    string Name,
    uint Level,
    uint Current,
    uint Target,
    uint Progress,
    DateTime? CompletedAt,
    Reward Reward
) : Achievement(Name, Progress, CompletedAt, Reward);
