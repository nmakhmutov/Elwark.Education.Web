using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public abstract record Achievement(string Name, uint Progress, Reward Reward);

public sealed record CommonAchievement(string Name, uint Progress, Reward Reward)
    : Achievement(Name, Progress, Reward);

public sealed record CumulativeAchievement(
    string Name,
    uint Level,
    uint Current,
    uint Target,
    uint Progress,
    Reward Reward
) : Achievement(Name, Progress, Reward);
