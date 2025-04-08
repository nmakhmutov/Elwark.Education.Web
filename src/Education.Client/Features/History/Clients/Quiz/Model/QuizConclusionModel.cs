using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizConclusionModel(
    string TestId,
    string ArticleId,
    string Title,
    DifficultyType Difficulty,
    QuizStatus Status,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> AccuracyBonus,
    PerformanceModel<uint> TimeBonus,
    PerformanceModel<uint> TotalScore,
    AnswerRatioModel Ratio,
    PerformanceModel<TimeSpan> TimeSpent,
    QuizConclusionModel.MetricsModel Metrics,
    Reward[] Rewards
)
{
    public sealed record MetricsModel(double AverageScore, double SuccessRate);

    public sealed record Question(string Title, bool IsCorrect);
}
