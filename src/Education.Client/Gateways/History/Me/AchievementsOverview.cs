namespace Education.Client.Gateways.History.Me;

public sealed record AchievementsOverview(uint Completed, uint Total, Achievement[] Items);
