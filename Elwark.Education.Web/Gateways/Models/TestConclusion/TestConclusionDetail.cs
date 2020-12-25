using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusionDetail(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        AnswerConclusion[] Answers
    );
    
    public sealed record ArticleTestConclusionDetail(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string ArticleId,
        AnswerConclusion[] Answers
    ) : TestConclusionDetail(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt, Answers);
    
    public sealed record TopicTestConclusionDetail(
        string TestId,
        string? Title,
        bool IsComplete,
        Score Score,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        string TopicId,
        AnswerConclusion[] Answers
    ) : TestConclusionDetail(TestId, Title, IsComplete, Score, TimeSpent, CreatedAt, Answers);
}