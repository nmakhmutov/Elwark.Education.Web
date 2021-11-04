namespace Education.Client.Gateways.History.Me;

public sealed record AchievementStatistics(string Category, uint Total, uint Completed, Achievement[] Achievements);
