using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Test.Model;

public abstract record TestConclusion(
    string TestId,
    TestStatus Status,
    ScoreModel MaxScore,
    TimeSpan TestDuration,
    ScoreModel UserScore,
    TimeSpan TimeSpent,
    IInternalMoney[] Rewards,
    DateTime CompletedAt
)
{
    public sealed record EasyTestModel(
        string TestId,
        ArticleTitleModel Article,
        TestStatus Status,
        ScoreModel MaxScore,
        TimeSpan TestDuration,
        ScoreModel UserScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt,
        IInternalMoney[] Rewards,
        EasyTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
    {
        public sealed record Question(string Title, bool IsAnswered, uint Correct, uint Incorrect);
    }

    public sealed record HardTestModel(
        string TestId,
        ArticleTitleModel Article,
        TestStatus Status,
        ScoreModel MaxScore,
        TimeSpan TestDuration,
        ScoreModel UserScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt,
        IInternalMoney[] Rewards,
        HardTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
    {
        public sealed record Question(string Title, bool IsAnswered, bool IsCorrect);
    }

    public sealed record MixedTestModel(
        string TestId,
        TestStatus Status,
        ScoreModel MaxScore,
        TimeSpan TestDuration,
        ScoreModel UserScore,
        TimeSpan TimeSpent,
        DateTime CompletedAt,
        IInternalMoney[] Rewards,
        MixedTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, MaxScore, TestDuration, UserScore, TimeSpent, Rewards, CompletedAt)
    {
        public sealed record Question(string Title, bool IsAnswered, bool IsCorrect, ArticleTitleModel Article);
    }
}
