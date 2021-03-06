using System;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleTest(
        PermissionStatus Status,
        uint QuantityCompletedTimes,
        ProgressTestConclusion[] Conclusions
    );
    
    public sealed record ProgressTestConclusion(
        string TestId,
        ConclusionStatus Status,
        ulong TotalScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
