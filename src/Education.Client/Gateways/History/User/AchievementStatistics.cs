namespace Education.Client.Gateways.History.User;

public sealed record AchievementStatistics(string Category, uint Total, uint Completed, Achievement[] Achievements);
