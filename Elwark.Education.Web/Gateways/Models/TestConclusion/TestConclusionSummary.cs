using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record TestConclusionSummary(
        string TestId,
        string TopicId,
        string? Title,
        ConclusionStatus Status,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    );
}
