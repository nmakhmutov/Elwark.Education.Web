using System;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Topic
{
    public sealed record TopicStatistics(TopicTestStatistics EasyTest, TopicTestStatistics HardTest);
    
    public sealed record TopicTestStatistics(
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        NumberOfTests NumberOfTests,
        TopicTestConclusion[] Conclusions
    );
}
