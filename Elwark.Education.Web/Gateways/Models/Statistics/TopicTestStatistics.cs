namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TopicTestStatistics(
        ScoreStatistics Score,
        AnswerRatioStatistics AnswerRatio,
        TimeSpentStatistics TimeSpent,
        NumberOfTestsStatistics NumberOfTests,
        TopicTestConclusion[] Conclusions
    );
}
