using System;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    internal sealed record TopicStatistics(
        TopicTestStatistics EasyTest,
        TopicTestStatistics HardTest,
        TestConclusionOverview[] Conclusions
    );
    
    internal sealed record TopicTestStatistics(
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTests NumberOfTests
    );
}
