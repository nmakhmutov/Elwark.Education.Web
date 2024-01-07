using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Components.Lists;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My;

public static class StatisticsExtensions
{
    public static string RangeTitle(this ExaminationStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this QuizStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this DateGuesserStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static ProgressList.Item[] GetProgress(
        this ExaminationStatisticsModel.NumberOfExaminationsContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["NumberOfQuizzes_Successful_Title"], contrast.Successful.Current.ToMetric(),
            contrast.Successful.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_Failed_Title"], contrast.Failed.Current.ToMetric(),
            contrast.Failed.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded.Current.ToMetric(),
            contrast.TimeExceeded.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_Total_Title"], contrast.Total.Current.ToMetric(),
            contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this ExaminationStatisticsModel.ScoreContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["Score_Questions_Title"], contrast.Questions.Current.ToMetric(),
            contrast.Questions.Difference),
        new ProgressList.Item(l["Score_SpeedBonus_Title"], contrast.Speed.Current.ToMetric(),
            contrast.Speed.Difference),
        new ProgressList.Item(l["Score_NoMistakesBonus_Title"], contrast.NoMistakes.Current.ToMetric(),
            contrast.NoMistakes.Difference),
        new ProgressList.Item(l["Score_Total_Title"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this ExaminationStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["Questions_Answered"], contrast.Answered.Current.ToMetric(),
            contrast.Answered.Difference),
        new ProgressList.Item(l["Questions_NotAnswered"], contrast.NotAnswered.Current.ToMetric(),
            contrast.NotAnswered.Difference),
        new ProgressList.Item(l["Questions_Correct"], contrast.Correct.Current.ToMetric(),
            contrast.Questions.Difference),
        new ProgressList.Item(l["Questions_Incorrect"], contrast.Incorrect.Current.ToMetric(),
            contrast.Incorrect.Difference),
        new ProgressList.Item(l["Questions_Total"], contrast.Questions.Current.ToMetric(),
            contrast.Questions.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this ExaminationStatisticsModel.TimeSpentContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["TimeSpent_Min_Title"], contrast.Min.Current.Humanize(l), contrast.Min.Difference),
        new ProgressList.Item(l["TimeSpent_Max_Title"], contrast.Max.Current.Humanize(l), contrast.Max.Difference),
        new ProgressList.Item(l["TimeSpent_Average_Title"], contrast.Average.Current.Humanize(l),
            contrast.Average.Difference),
        new ProgressList.Item(l["TimeSpent_Total_Title"], contrast.Total.Current.Humanize(l), contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.NumberOfQuizzesContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["NumberOfQuizzes_Successful_Title"], contrast.Successful.Current.ToMetric(),
            contrast.Successful.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_Failed_Title"], contrast.Failed.Current.ToMetric(),
            contrast.Failed.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded.Current.ToMetric(),
            contrast.TimeExceeded.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_MistakesExceeded_Title"], contrast.MistakesExceeded.Current.ToMetric(),
            contrast.MistakesExceeded.Difference),
        new ProgressList.Item(l["NumberOfQuizzes_Total_Title"], contrast.Total.Current.ToMetric(),
            contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.ScoreContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["Score_Questions_Title"], contrast.Questions.Current.ToMetric(),
            contrast.Questions.Difference),
        new ProgressList.Item(l["Score_SpeedBonus_Title"], contrast.Speed.Current.ToMetric(),
            contrast.Speed.Difference),
        new ProgressList.Item(l["Score_NoMistakesBonus_Title"], contrast.NoMistakes.Current.ToMetric(),
            contrast.NoMistakes.Difference),
        new ProgressList.Item(l["Score_Total_Title"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["Questions_Answered"], contrast.Answered.Current.ToMetric(),
            contrast.Answered.Difference),
        new ProgressList.Item(l["Questions_NotAnswered"], contrast.NotAnswered.Current.ToMetric(),
            contrast.NotAnswered.Difference),
        new ProgressList.Item(l["Questions_Correct"], contrast.Correct.Current.ToMetric(),
            contrast.Questions.Difference),
        new ProgressList.Item(l["Questions_Incorrect"], contrast.Incorrect.Current.ToMetric(),
            contrast.Incorrect.Difference),
        new ProgressList.Item(l["Questions_Total"], contrast.Questions.Current.ToMetric(),
            contrast.Questions.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.TimeSpentContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["TimeSpent_Min_Title"], contrast.Min.Current.Humanize(l), contrast.Min.Difference),
        new ProgressList.Item(l["TimeSpent_Max_Title"], contrast.Max.Current.Humanize(l), contrast.Max.Difference),
        new ProgressList.Item(l["TimeSpent_Average_Title"], contrast.Average.Current.Humanize(l),
            contrast.Average.Difference),
        new ProgressList.Item(l["TimeSpent_Total_Title"], contrast.Total.Current.Humanize(l), contrast.Total.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this DateGuesserStatisticsModel.DeltaModel delta, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["History_DateGuesser_Total"], delta.Tests.Current.ToMetric(), delta.Tests.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this DateGuesserStatisticsModel.ScoreContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["History_DateGuesser_Score"], contrast.Total.Current.ToMetric(),
            contrast.Total.Difference),
        new ProgressList.Item(l["History_DateGuesser_Points"], contrast.Points.Current.ToMetric(),
            contrast.Points.Difference),
        new ProgressList.Item(l["History_DateGuesser_x2Bonus"], contrast.Bonus.Current.ToMetric(),
            contrast.Bonus.Difference)
    ];

    public static ProgressList.Item[] GetProgress(
        this DateGuesserStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer l) =>
    [
        new ProgressList.Item(l["History_DateGuesser_Questions"], contrast.Total.Current.ToMetric(),
            contrast.Total.Difference),
        new ProgressList.Item(l["History_DateGuesser_Correct"], contrast.Correct.Current.ToMetric(),
            contrast.Correct.Difference),
        new ProgressList.Item(l["History_DateGuesser_Incorrect"], contrast.Incorrect.Current.ToMetric(),
            contrast.Incorrect.Difference)
    ];

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
