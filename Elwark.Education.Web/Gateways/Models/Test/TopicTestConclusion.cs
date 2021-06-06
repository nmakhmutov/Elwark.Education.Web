using System;

namespace Elwark.Education.Web.Gateways.Models.Test
{
    public sealed record TopicTestConclusion(
        ConclusionStatus Status,
        TestType TestType,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
