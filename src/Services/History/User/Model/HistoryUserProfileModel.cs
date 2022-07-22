using Education.Web.Services.Model.Test;
using Education.Web.Services.Model.User;

namespace Education.Web.Services.History.User.Model;

public sealed record HistoryUserProfileModel(
    LevelModel Level,
    SilverWalletModel Silver,
    DailyBonusModel DailyBonus,
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
