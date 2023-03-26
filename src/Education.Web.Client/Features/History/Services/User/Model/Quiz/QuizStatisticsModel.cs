using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Models.Statistics;

namespace Education.Web.Client.Features.History.Services.User.Model.Quiz;

public sealed record QuizStatisticsModel(
    ScoreModel Score,
    AnswerRatioModel AnswerRatio,
    NumberOfQuizzesModel NumberOfQuizzes,
    QuizStatisticsModel.TimeSpentModel TimeSpent,
    QuizStatisticsModel.ContrastModel RangeContrast,
    QuizStatisticsModel.DailyProgress[] Progress
)
{
    public sealed record ContrastModel(
        DateOnly Starts,
        DateOnly Ends,
        ScoreContrastModel Score,
        AnswerRatioContrastModel AnswerRatio,
        TimeSpentContrastModel TimeSpent,
        NumberOfQuizzesContrastModel NumberOfQuizzes
    );

    public sealed record ScoreContrastModel(
        ContrastModel<ulong> Total,
        ContrastModel<uint> Questions,
        ContrastModel<uint> NoMistakes,
        ContrastModel<uint> Speed
    );

    public sealed record AnswerRatioContrastModel(
        ContrastModel<uint> Questions,
        ContrastModel<uint> Answered,
        ContrastModel<uint> NotAnswered,
        ContrastModel<uint> Correct,
        ContrastModel<uint> Incorrect
    );

    public sealed record TimeSpentContrastModel(
        ContrastModel<TimeSpan> Total,
        ContrastModel<TimeSpan> Average,
        ContrastModel<TimeSpan> Min,
        ContrastModel<TimeSpan> Max
    );

    public sealed record NumberOfQuizzesContrastModel(
        ContrastModel<uint> Successful,
        ContrastModel<uint> Failed,
        ContrastModel<uint> TimeExceeded,
        ContrastModel<uint> MistakesExceeded,
        ContrastModel<ulong> Total
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
