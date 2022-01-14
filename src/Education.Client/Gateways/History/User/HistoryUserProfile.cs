using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.User;

public sealed record HistoryUserProfile(
    SubscriptionType Subscription,
    Level Level,
    Wallet Wallet,
    DailyReward DailyReward,
    Restriction TestCreationRestriction,
    Restriction TestMistakesRestriction,
    Restriction EventGuesserRestriction,
    double TestDurationCoefficient,
    HistoryUserProfile.TestOverview EasyTestStatistic,
    HistoryUserProfile.TestOverview HardTestStatistic,
    HistoryUserProfile.TestOverview MixedTestStatistic,
    HistoryUserProfile.EventGuesserOverview EventGuesserStatistic,
    Achievements Achievements,
    HistoryUserProfile.ProgressOverview[] TestProgress,
    Transaction[] Transactions
)
{
    public sealed record TestOverview(NumberOfTests NumberOfTests, Score Score);

    public sealed record EventGuesserOverview(uint Tests, uint Score, uint Points, uint Bonus);

    public sealed record ProgressOverview(DateTime Date, uint Total);
}
