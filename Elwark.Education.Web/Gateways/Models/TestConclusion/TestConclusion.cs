using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt
    );

    public sealed record ArticleTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string ArticleId
    ) : TestConclusion(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt);

    public sealed record TopicTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string TopicId
    ) : TestConclusion(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt);
}