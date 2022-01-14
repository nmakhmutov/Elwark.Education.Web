namespace Education.Client.Gateways.Models.Statistics;

public sealed record TestStatistics(
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpent TimeSpent,
    NumberOfTests NumberOfTests,
    TestRangeContrast RangeContrast,
    IEnumerable<TestStatistics.DailyProgress> Progress
)
{
    public sealed record DailyProgress(
        DateTime Date,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpent TimeSpent,
        NumberOfTests NumberOfTests
    );
}
