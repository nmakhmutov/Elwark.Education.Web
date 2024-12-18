using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Statistics;

namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record ExaminationStatisticsModel(
    ScoreModel Score,
    AnswerRatioModel Ratio,
    NumberOfExaminationsModel NumberOfExaminations,
    ExaminationStatisticsModel.TimeSpentModel TimeSpent,
    ExaminationStatisticsModel.DeltaModel Delta,
    ExaminationStatisticsModel.DailyProgress[] Progress
)
{
    public sealed record DeltaModel(
        DateOnly Start,
        DateOnly End,
        ScoreContrastModel Score,
        AnswerRatioContrastModel Ratio,
        TimeSpentContrastModel TimeSpent,
        NumberOfExaminationsContrastModel NumberOfExaminations
    );

    public sealed record ScoreContrastModel(
        DeltaModel<uint> Questions,
        DeltaModel<uint> AccuracyBonus,
        DeltaModel<uint> TimeBonus,
        DeltaModel<ulong> Total
    );

    public sealed record AnswerRatioContrastModel(
        DeltaModel<uint> Questions,
        DeltaModel<uint> Answered,
        DeltaModel<uint> NotAnswered,
        DeltaModel<uint> Correct,
        DeltaModel<uint> Incorrect
    );

    public sealed record TimeSpentContrastModel(
        DeltaModel<TimeSpan> Total,
        DeltaModel<TimeSpan> Average,
        DeltaModel<TimeSpan> Min,
        DeltaModel<TimeSpan> Max
    );

    public sealed record NumberOfExaminationsContrastModel(
        DeltaModel<uint> Successful,
        DeltaModel<uint> Failed,
        DeltaModel<uint> TimeExceeded,
        DeltaModel<ulong> Total
    );

    public sealed record DailyProgress(
        DateOnly Date,
        ScoreModel Score,
        AnswerRatioModel Ratio,
        TimeSpentModel TimeSpent,
        NumberOfExaminationsModel NumberOfExaminations
    );

    public sealed record TimeSpentModel(TimeSpan Total, TimeSpan Average, TimeSpan Min, TimeSpan Max);
}
