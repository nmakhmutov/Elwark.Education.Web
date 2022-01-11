using System;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.User;

public sealed record TopicStatistics(
    TopicSummary Topic,
    TopicStatistics.TotalProgress Progress,
    TopicStatistics.Statistics EasyTest,
    TopicStatistics.Statistics HardTest
)
{
    public sealed record TotalProgress(ulong Tests, ulong Score, uint Questions, TimeSpan TimeSpent);

    public sealed record Statistics(
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTests NumberOfTests,
        TopicTestConclusion[] Conclusions
    );
}
