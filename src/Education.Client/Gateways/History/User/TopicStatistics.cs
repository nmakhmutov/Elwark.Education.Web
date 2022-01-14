using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.User;

public sealed record TopicStatistics(
    HistoryTopicSummary Topic,
    TopicStatistics.TotalStatistics Total,
    TopicStatistics.TestProgress EasyTest,
    TopicStatistics.TestProgress HardTest
)
{
    public sealed record TotalStatistics(ulong Tests, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record TestProgress(
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTests NumberOfTests,
        TopicTestConclusion[] Conclusions
    );
}
