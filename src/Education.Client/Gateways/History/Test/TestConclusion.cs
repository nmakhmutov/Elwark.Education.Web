using System;
using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test;

public abstract record TestConclusion(
    string TestId,
    ConclusionStatus Status,
    Score MaxScore,
    TimeSpan TestDuration,
    Score UserScore,
    TimeSpan TimeSpent,
    Reward Reward,
    DateTime CompletedAt
);

public sealed record EasyTestConclusion(
    string TestId,
    TopicTitle Topic,
    ConclusionStatus Status,
    Score MaxScore,
    TimeSpan TestDuration,
    Score UserScore,
    TimeSpan TimeSpent,
    Reward Reward,
    DateTime CompletedAt,
    EasyTestConclusion.Question[] Questions
) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Reward, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, uint Correct, uint Incorrect);
}

public sealed record HardTestConclusion(
    string TestId,
    TopicTitle Topic,
    ConclusionStatus Status,
    Score MaxScore,
    TimeSpan TestDuration,
    Score UserScore,
    TimeSpan TimeSpent,
    Reward Reward,
    DateTime CompletedAt,
    HardTestConclusion.Question[] Questions
) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Reward, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, bool IsCorrect);
}

public sealed record MixedTestConclusion(
    string TestId,
    ConclusionStatus Status,
    Score MaxScore,
    TimeSpan TestDuration,
    Score UserScore,
    TimeSpan TimeSpent,
    Reward Reward,
    DateTime CompletedAt,
    MixedTestConclusion.Question[] Questions
) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Reward, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, bool IsCorrect, TopicTitle Topic);
}
