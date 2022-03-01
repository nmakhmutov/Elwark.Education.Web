using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Tests.Model;

public abstract record TestConclusionModel(
    string TestId,
    ConclusionStatus Status,
    ScoreModel MaxScore,
    TimeSpan TestDuration,
    ScoreModel UserScore,
    TimeSpan TimeSpent,
    IInternalMoney[] Rewards,
    DateTime CompletedAt
);

public sealed record EasyTestConclusionModel(
    string TestId,
    TopicTitleModel Topic,
    ConclusionStatus Status,
    ScoreModel MaxScore,
    TimeSpan TestDuration,
    ScoreModel UserScore,
    TimeSpan TimeSpent,
    DateTime CompletedAt,
    IInternalMoney[] Rewards,
    EasyTestConclusionModel.Question[] Questions
) : TestConclusionModel(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, uint Correct, uint Incorrect);
}

public sealed record HardTestConclusionModel(
    string TestId,
    TopicTitleModel Topic,
    ConclusionStatus Status,
    ScoreModel MaxScore,
    TimeSpan TestDuration,
    ScoreModel UserScore,
    TimeSpan TimeSpent,
    DateTime CompletedAt,
    IInternalMoney[] Rewards,
    HardTestConclusionModel.Question[] Questions
) : TestConclusionModel(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, bool IsCorrect);
}

public sealed record MixedTestConclusionModel(
    string TestId,
    ConclusionStatus Status,
    ScoreModel MaxScore,
    TimeSpan TestDuration,
    ScoreModel UserScore,
    TimeSpan TimeSpent,
    DateTime CompletedAt,
    IInternalMoney[] Rewards,
    MixedTestConclusionModel.Question[] Questions
) : TestConclusionModel(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
{
    public sealed record Question(string Id, string Title, bool IsAnswered, bool IsCorrect, TopicTitleModel Topic);
}
