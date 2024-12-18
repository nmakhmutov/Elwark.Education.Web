using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Statistics;

namespace Education.Client.Features.History.Clients.Learner.Model.Quiz;

public sealed record QuizStatisticsModel(
    ScoreModel Score,
    AnswerRatioModel Ratio,
    NumberOfQuizzesModel NumberOfQuizzes,
    QuizStatisticsModel.TimeSpentModel TimeSpent,
    QuizStatisticsModel.DeltaModel Delta,
    QuizStatisticsModel.DailyProgress[] Progress
)
{
    public sealed record DeltaModel(
        DateOnly Start,
        DateOnly End,
        ScoreContrastModel Score,
        AnswerRatioContrastModel Ratio,
        TimeSpentContrastModel TimeSpent,
        NumberOfQuizzesContrastModel NumberOfQuizzes
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

    public sealed record NumberOfQuizzesContrastModel(
        DeltaModel<uint> Successful,
        DeltaModel<uint> Failed,
        DeltaModel<uint> TimeExceeded,
        DeltaModel<uint> MistakesLimitExceeded,
        DeltaModel<ulong> Total
    );

    public sealed record DailyProgress(
        DateOnly Date,
        ScoreModel Score,
        AnswerRatioModel Ratio,
        TimeSpentModel TimeSpent,
        NumberOfQuizzesModel NumberOfQuizzes
    );

    public sealed record TimeSpentModel(TimeSpan Total, TimeSpan Average, TimeSpan Min, TimeSpan Max);
}
