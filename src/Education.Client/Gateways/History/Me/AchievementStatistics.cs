namespace Education.Client.Gateways.History.Me;

public sealed record AchievementStatistics(
    uint Total,
    Achievement[] InProgress,
    Achievement[] Completed
);
