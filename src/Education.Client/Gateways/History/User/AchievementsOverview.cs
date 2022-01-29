namespace Education.Client.Gateways.History.User;

public sealed record AchievementsOverview(uint Total, uint Completed, Achievement[] Items);
