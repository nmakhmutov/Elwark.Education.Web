namespace Education.Client.Gateways.Models.Test;

public sealed record TopicTestConclusionModel(
    ConclusionStatus Status,
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
    TimeSpan TimeSpent,
    DateTime CompletedAt
);
