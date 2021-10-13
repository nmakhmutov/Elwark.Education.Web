using System;
using Education.Client.Gateways.Models.Progress;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.Statistics;

public sealed record MixedTestStatistics(
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpent TimeSpent,
    NumberOfTests NumberOfTests,
    WeeklyProgress Progress,
    MixedTestConclusion[] Conclusions
);
    
public sealed record MixedTestConclusion(
    ConclusionStatus Status,
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpan TimeSpent,
    DateTime CompletedAt
);