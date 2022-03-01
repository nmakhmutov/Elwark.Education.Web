using Education.Client.Gateways.Models.Test;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Users.Model;

public sealed record HistoryUserProfileModel(
    LevelModel Level,
    SilverWalletModel Silver,
    DailyRewardModel DailyReward,
    HistoryUserProfileModel.TestOverview EasyTest,
    HistoryUserProfileModel.TestOverview HardTest,
    HistoryUserProfileModel.TestOverview MixedTest,
    HistoryUserProfileModel.EventGuesserOverview EventGuesser,
    InventoryOverviewModel Inventory,
    AchievementsOverviewModel Achievements,
    HistoryUserProfileModel.TestActivity[] Activity
)
{
    public sealed record TestOverview(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserOverview(uint Tests, uint Score, uint Points, uint Bonus);

    public sealed record TestActivity(DateOnly Date, uint Total);
}
