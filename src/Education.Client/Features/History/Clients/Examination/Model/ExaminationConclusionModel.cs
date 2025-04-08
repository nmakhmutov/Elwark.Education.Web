using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ExaminationConclusionModel(
    string TestId,
    string CourseId,
    string Title,
    DifficultyType Difficulty,
    ExaminationStatus Status,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> AccuracyBonus,
    PerformanceModel<uint> TimeBonus,
    PerformanceModel<uint> TotalScore,
    PerformanceModel<TimeSpan> TimeSpent,
    ExaminationConclusionModel.MetricsModel Metrics,
    AnswerRatioModel Ratio,
    ExaminationConclusionModel.Question[] Questions,
    Reward[] Rewards
)
{
    public sealed record MetricsModel(double AverageScore, double SuccessRate);

    public sealed record Question(string Title, bool IsCorrect);
}
