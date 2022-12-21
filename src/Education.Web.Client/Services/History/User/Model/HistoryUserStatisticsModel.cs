using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record HistoryUserStatisticsModel(
    HistoryUserStatisticsModel.TestOverview EasyTest,
    HistoryUserStatisticsModel.TestOverview HardTest,
    HistoryUserStatisticsModel.TestOverview MixedTest,
    HistoryUserStatisticsModel.EventGuesserOverview EventGuesser,
    HistoryUserStatisticsModel.Progress[] Daily,
    HistoryUserStatisticsModel.Progress[] Monthly
)
{
    public sealed record TestOverview(NumberOfTestsModel NumberOfTests, ScoreModel Score);

    public sealed record EventGuesserOverview(uint Tests, uint Score, uint Points, uint Bonus);

    public sealed record Progress(
        DateOnly Date,
        uint Total,
        uint EasyTests,
        uint HardTests,
        uint MixedTests,
        uint EventGuessers
    )
    {
        public static Progress Empty(DateOnly date) =>
            new(date, 0, 0, 0, 0, 0);
    }
}
