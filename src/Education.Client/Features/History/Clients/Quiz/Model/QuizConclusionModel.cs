using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizConclusionModel(
    string TestId,
    string ArticleId,
    string Title,
    DifficultyType Difficulty,
    QuizStatus Status,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> NoMistakeScore,
    PerformanceModel<uint> SpeedScore,
    PerformanceModel<uint> TotalScore,
    PerformanceModel<TimeSpan> TimeSpent,
    QuizConclusionModel.MetricsModel Metrics,
    QuizConclusionModel.Question[] Questions,
    InternalMoneyModel[] Rewards
)
{
    public sealed record MetricsModel(double AverageScore, double SuccessRate);

    public sealed record Question(string Title, bool IsAnswered, uint Correct, uint Incorrect);
}
