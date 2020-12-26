using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public abstract record TestConclusionDetail(
        string TestId,
        string? Title,
        ConclusionStatus Status,
        Score MaxScore,
        TimeSpan TestDuration,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        AnswerConclusion[] Answers
    );

    public sealed record ArticleTestConclusionDetail(
        string TestId,
        string ArticleId,
        string? Title,
        ConclusionStatus Status,
        Score MaxScore,
        TimeSpan TestDuration,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        AnswerConclusion[] Answers
    ) : TestConclusionDetail(TestId, Title, Status, MaxScore, TestDuration, UserScore, TimeSpent, CreatedAt, Answers);

    public sealed record TopicTestConclusionDetail(
        string TestId,
        string TopicId,
        string? Title,
        ConclusionStatus Status,
        Score MaxScore,
        TimeSpan TestDuration,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CreatedAt,
        AnswerConclusion[] Answers
    ) : TestConclusionDetail(TestId, Title, Status, MaxScore, TestDuration, UserScore, TimeSpent, CreatedAt, Answers);
}