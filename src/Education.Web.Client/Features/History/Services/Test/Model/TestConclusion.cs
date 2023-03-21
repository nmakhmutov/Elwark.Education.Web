using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Test.Model;

public abstract record TestConclusion(
    string TestId,
    TestStatus Status,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> NoMistakeScore,
    PerformanceModel<uint> SpeedScore,
    PerformanceModel<uint> TotalScore,
    PerformanceModel<TimeSpan> TimeSpent,
    IInternalMoney[] Rewards
)
{
    public sealed record EasyTestModel(
        string TestId,
        ArticleTitleModel Article,
        TestStatus Status,
        PerformanceModel<uint> QuestionScore,
        PerformanceModel<uint> NoMistakeScore,
        PerformanceModel<uint> SpeedScore,
        PerformanceModel<uint> TotalScore,
        PerformanceModel<TimeSpan> TimeSpent,
        IInternalMoney[] Rewards,
        EasyTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, QuestionScore, NoMistakeScore, SpeedScore, TotalScore, TimeSpent, Rewards)
    {
        public sealed record Question(string Title, bool IsAnswered, uint Correct, uint Incorrect);
    }

    public sealed record HardTestModel(
        string TestId,
        ArticleTitleModel Article,
        TestStatus Status,
        PerformanceModel<uint> QuestionScore,
        PerformanceModel<uint> NoMistakeScore,
        PerformanceModel<uint> SpeedScore,
        PerformanceModel<uint> TotalScore,
        PerformanceModel<TimeSpan> TimeSpent,
        IInternalMoney[] Rewards,
        HardTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, QuestionScore, NoMistakeScore, SpeedScore, TotalScore, TimeSpent, Rewards)
    {
        public sealed record Question(string Title, bool IsAnswered, bool IsCorrect);
    }

    public sealed record MixedTestModel(
        string TestId,
        TestStatus Status,
        PerformanceModel<uint> QuestionScore,
        PerformanceModel<uint> NoMistakeScore,
        PerformanceModel<uint> SpeedScore,
        PerformanceModel<uint> TotalScore,
        PerformanceModel<TimeSpan> TimeSpent,
        IInternalMoney[] Rewards,
        MixedTestModel.Question[] Questions
    ) : TestConclusion(TestId, Status, QuestionScore, NoMistakeScore, SpeedScore, TotalScore, TimeSpent, Rewards)
    {
        public sealed record Question(string Title, bool IsAnswered, bool IsCorrect, ArticleTitleModel Article);
    }
}
