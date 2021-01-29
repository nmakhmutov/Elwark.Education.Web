using System;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleTest(
        TestStatus Status,
        ArticleProgress? Progress,
        ProgressTestConclusion[] Conclusions
    ) : ArticleTestSummary(Status, Progress);
    
    public sealed record ProgressTestConclusion(
        string TestId,
        ConclusionStatus Status,
        ulong TotalScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}