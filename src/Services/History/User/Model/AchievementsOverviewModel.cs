namespace Education.Web.Services.History.User.Model;

public sealed record AchievementsOverviewModel(uint Total, uint Completed, AchievementModel[] Items);
