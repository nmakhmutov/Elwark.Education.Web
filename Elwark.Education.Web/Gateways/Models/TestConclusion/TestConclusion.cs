using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt
    );

    public sealed record ArticleTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt,
        string ArticleId
    ) : TestConclusion(TestId, Title, IsComplete, Score, ElapsedTime, CreatedAt);

    public sealed record TopicTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt,
        string TopicId
    ) : TestConclusion(TestId, Title, IsComplete, Score, ElapsedTime, CreatedAt);
}