using Education.Web.Client.Models;
using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizConclusionModel(
    string TestId,
    DifficultyType Type,
    QuizStatus Status,
    ArticleTitleModel Article,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> NoMistakeScore,
    PerformanceModel<uint> SpeedScore,
    PerformanceModel<uint> TotalScore,
    PerformanceModel<TimeSpan> TimeSpent,
    QuizConclusionModel.Question[] Questions,
    InternalMoneyModel[] Rewards
)
{
    public sealed record Question(string Title, bool IsAnswered, uint Correct, uint Incorrect);
}
