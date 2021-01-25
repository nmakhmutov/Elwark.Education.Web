using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusionSummary(
        string TestId,
        string? Title,
        ConclusionStatus Status,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    );

    public sealed record ArticleTestConclusionSummary(
        string TestId,
        string ArticleId,
        string? Title,
        ConclusionStatus Status,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    ) : TestConclusionSummary(TestId, Title, Status, UserScore, TimeSpent, CreatedAt);

    public sealed record TopicTestConclusionSummary(
        string TestId,
        string TopicId,
        string? Title,
        ConclusionStatus Status,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    ) : TestConclusionSummary(TestId, Title, Status, UserScore, TimeSpent, CreatedAt);
}