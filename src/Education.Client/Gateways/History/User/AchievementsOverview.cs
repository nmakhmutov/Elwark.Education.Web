namespace Education.Client.Gateways.History.User;

public sealed record AchievementsOverview(uint Completed, uint Total, Achievement[] Items);
