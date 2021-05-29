using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record TestConclusion(
        string Id,
        ConclusionStatus Status,
        TestDifficulty Difficulty,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
