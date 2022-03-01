using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Users.Model;

public sealed record TopicStatisticsModel(
    TopicOverviewModel Topic,
    TopicStatisticsModel.TotalStatistics Total,
    TopicStatisticsModel.TestProgress EasyTest,
    TopicStatisticsModel.TestProgress HardTest
)
{
    public sealed record TotalStatistics(ulong Tests, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record TestProgress(
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTestsModel NumberOfTests,
        TopicTestConclusionModel[] Conclusions
    );
}
