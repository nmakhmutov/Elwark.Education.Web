using System;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.Statistics
{
    public sealed record MixedTestConclusion(
        ConclusionStatus Status,
        Score Score,
        AnswerRatio AnswerRatio,
        TimeSpan TimeSpent,
        DateTime CompletedAt
    );
}
