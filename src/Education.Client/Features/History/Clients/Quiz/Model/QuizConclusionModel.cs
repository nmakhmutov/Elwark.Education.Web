using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizConclusionModel(
    string TestId,
    string ArticleId,
    string Title,
    DifficultyType Type,
    QuizStatus Status,
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
