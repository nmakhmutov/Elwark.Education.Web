using Education.Web.Client.Services.History.Test.Model;
using Education.Web.Client.Services.History.User.Model.Test;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record HistoryUserStatisticsModel(
    HistoryUserStatisticsModel.TestOverview EasyTest,
    HistoryUserStatisticsModel.TestOverview HardTest,
    HistoryUserStatisticsModel.TestOverview MixedTest,
    HistoryUserStatisticsModel.EventGuesserOverview SmallEventGuesser,
    HistoryUserStatisticsModel.EventGuesserOverview MediumEventGuesser,
    HistoryUserStatisticsModel.EventGuesserOverview LargeEventGuesser,
    HistoryUserStatisticsModel.Progress[] Daily,
    HistoryUserStatisticsModel.Progress[] Monthly
)
{
    public sealed record TestOverview(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserOverview(uint Tests, History.EventGuesser.Model.ScoreModel Score);

    public sealed record Progress(
        DateOnly Date,
        uint Total,
        uint EasyTests,
        uint HardTests,
        uint MixedTests,
        uint SmallEventGuessers,
        uint MediumEventGuessers,
        uint LargeEventGuessers
    );
}
