using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record TestConclusionDetail(
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
    );
}
