using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public abstract record TestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt
    );

    internal sealed record ArticleTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt,
        string ArticleId
    ) : TestConclusion(TestId, Title, IsComplete, Score, ElapsedTime, CreatedAt);

    internal sealed record TopicTestConclusion(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan ElapsedTime,
        DateTime CreatedAt,
        string TopicId
    ) : TestConclusion(TestId, Title, IsComplete, Score, ElapsedTime, CreatedAt);
}