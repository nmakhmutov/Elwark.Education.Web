using System;
using Elwark.Education.Web.Gateways.Models;
using Elwark.Education.Web.Gateways.Models.Test;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.History.Test
{
    internal sealed record TestConclusion(
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
