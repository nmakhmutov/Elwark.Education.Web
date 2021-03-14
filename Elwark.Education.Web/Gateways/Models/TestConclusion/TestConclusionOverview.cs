using System;

namespace Elwark.Education.Web.Gateways.Models.TestConclusion
{
    public sealed record TestConclusionOverview(
        string TestId,
        ConclusionStatus Status,
        ulong TotalScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
