using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record TestConclusionDetail(
        string TestId,
        string TopicId,
        string? Title,
        ConclusionStatus Status,
        TestDifficulty Difficulty,
        Score MaxScore,
        TimeSpan TestDuration,
        Score UserScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt,
        AnswerConclusion[] Answers
    );
}
