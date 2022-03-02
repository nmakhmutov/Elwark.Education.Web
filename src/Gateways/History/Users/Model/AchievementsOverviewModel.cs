namespace Education.Web.Gateways.History.Users.Model;

public sealed record AchievementsOverviewModel(uint Total, uint Completed, AchievementModel[] Items);
