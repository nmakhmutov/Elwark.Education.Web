using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusionSummary(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    );

    public sealed record ArticleTestConclusionSummary(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string ArticleId
    ) : TestConclusionSummary(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt);

    public sealed record TopicTestConclusionSummary(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string TopicId
    ) : TestConclusionSummary(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt);
}