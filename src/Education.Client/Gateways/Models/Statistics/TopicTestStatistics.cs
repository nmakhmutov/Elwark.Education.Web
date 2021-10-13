using System;
using Education.Client.Gateways.Models.Progress;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Models.Statistics;

public sealed record TopicTestStatistics(
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpent TimeSpent,
    NumberOfTests NumberOfTests,
    WeeklyProgress Progress,
    TopicTestConclusion[] Conclusions
);
    
public sealed record TopicTestConclusion(
    string TopicId,
    string Title,
    ConclusionStatus Status,
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpan TimeSpent,
    DateTime CompletedAt
);