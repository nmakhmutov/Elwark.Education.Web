using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    internal sealed record TestConclusionOverview(
        string TestId,
        ConclusionStatus Status,
        TestDifficulty Difficulty,
        ulong TotalScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
