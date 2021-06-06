namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TestStatistics(
        ScoreStatistics Score,
        AnswerRatioStatistics AnswerRatio,
        TimeSpentStatistics TimeSpent,
        NumberOfTestsStatistics NumberOfTests,
        TopicTestConclusion[] Conclusions
    );
}
