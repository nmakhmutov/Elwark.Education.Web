namespace Education.Client.Gateways.History.Users.Model;

public sealed record AchievementsOverviewModel(uint Total, uint Completed, AchievementModel[] Items);
