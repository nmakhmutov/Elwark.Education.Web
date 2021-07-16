namespace Education.Client.Gateways.Models.Statistics
{
    public sealed record MixedTestStatistics(
        ScoreStatistics Score,
        AnswerRatioStatistics AnswerRatio,
        TimeSpentStatistics TimeSpent,
        NumberOfTestsStatistics NumberOfTests,
        MixedTestConclusion[] Conclusions
    );
}
