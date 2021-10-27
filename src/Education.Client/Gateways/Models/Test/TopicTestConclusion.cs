using System;

namespace Education.Client.Gateways.Models.Test;

public sealed record TopicTestConclusion(
    ConclusionStatus Status,
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpan TimeSpent,
    Reward Reward,
    DateTime CompletedAt
);
