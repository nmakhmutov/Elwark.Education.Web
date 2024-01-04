using Education.Client.Models;
using Education.Client.Models.Content;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ExaminationConclusionModel(
    string TestId,
    ExaminationStatus Status,
    CourseTitleModel Course,
    PerformanceModel<uint> QuestionScore,
    PerformanceModel<uint> NoMistakeScore,
    PerformanceModel<uint> SpeedScore,
    PerformanceModel<uint> TotalScore,
    PerformanceModel<TimeSpan> TimeSpent,
    ExaminationConclusionModel.Question[] Questions,
    InternalMoneyModel[] Rewards
)
{
    public sealed record Question(string Title, bool IsAnswered, bool IsCorrect);
}