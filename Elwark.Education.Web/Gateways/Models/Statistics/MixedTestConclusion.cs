using System;
using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record MixedTestConclusion(
        ConclusionStatus Status,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
