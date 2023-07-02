using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Models.Statistics;

namespace Education.Web.Client.Features.History.Services.Learner.Model.Quiz;

public sealed record QuizStatisticsModel(
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
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
        AnswerRatioContrastModel AnswerRatio,
        TimeSpentContrastModel TimeSpent,
        NumberOfQuizzesContrastModel NumberOfQuizzes
    );

    public sealed record ScoreContrastModel(
        DeltaModel<ulong> Total,
        DeltaModel<uint> Questions,
        DeltaModel<uint> NoMistakes,
        DeltaModel<uint> Speed
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
        DeltaModel<uint> MistakesExceeded,
        DeltaModel<ulong> Total
    );

    public sealed record DailyProgress(
        DateOnly Date,
        ScoreModel Score,
        AnswerRatioModel AnswerRatio,
        TimeSpentModel TimeSpent,
        NumberOfQuizzesModel NumberOfQuizzes
    );

    public sealed record TimeSpentModel(TimeSpan Total, TimeSpan Average, TimeSpan Min, TimeSpan Max);
}
