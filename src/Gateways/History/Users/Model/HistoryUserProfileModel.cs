using Education.Web.Gateways.Models.Test;
using Education.Web.Gateways.Models.User;

namespace Education.Web.Gateways.History.Users.Model;

public sealed record HistoryUserProfileModel(
    LevelModel Level,
    SilverWalletModel Silver,
    DailyRewardModel DailyReward,
    HistoryUserProfileModel.TestOverview EasyTest,
    HistoryUserProfileModel.TestOverview HardTest,
    HistoryUserProfileModel.TestOverview MixedTest,
    HistoryUserProfileModel.EventGuesserOverview EventGuesser,
    AchievementsOverviewModel Achievements,
    HistoryUserProfileModel.DailyItem[] DailyProgress
)
{
    public sealed record TestOverview(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserOverview(uint Tests, uint Score, uint Points, uint Bonus);

    public sealed record DailyItem(DateOnly Day, uint Total);
}
