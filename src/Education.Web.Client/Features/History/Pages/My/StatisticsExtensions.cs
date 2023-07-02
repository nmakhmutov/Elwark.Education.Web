using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Components.Lists;
using Education.Web.Client.Features.History.Services.Learner.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.Learner.Model.Quiz;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My;

public static class StatisticsExtensions
{
    public static string RangeTitle(this QuizStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this EventGuesserStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.NumberOfQuizzesContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["NumberOfQuizzes_Successful_Title"], contrast.Successful.Current.ToMetric(),
                contrast.Successful.Difference),
            new(l["NumberOfQuizzes_Failed_Title"], contrast.Failed.Current.ToMetric(), contrast.Failed.Difference),
            new(l["NumberOfQuizzes_MistakesExceeded_Title"], contrast.MistakesExceeded.Current.ToMetric(),
                contrast.MistakesExceeded.Difference),
            new(l["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded.Current.ToMetric(),
                contrast.TimeExceeded.Difference),
            new(l["NumberOfQuizzes_Total_Title"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.ScoreContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["Score_Questions_Title"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Score_SpeedBonus_Title"], contrast.Speed.Current.ToMetric(), contrast.Speed.Difference),
            new(l["Score_NoMistakesBonus_Title"], contrast.NoMistakes.Current.ToMetric(),
                contrast.NoMistakes.Difference),
            new(l["Score_Total_Title"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["Questions_Answered"], contrast.Answered.Current.ToMetric(), contrast.Answered.Difference),
            new(l["Questions_NotAnswered"], contrast.NotAnswered.Current.ToMetric(), contrast.NotAnswered.Difference),
            new(l["Questions_Correct"], contrast.Correct.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Questions_Incorrect"], contrast.Incorrect.Current.ToMetric(), contrast.Incorrect.Difference),
            new(l["Questions_Total"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.TimeSpentContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent_Min_Title"], contrast.Min.Current.Humanize(), contrast.Min.Difference),
            new(l["TimeSpent_Max_Title"], contrast.Max.Current.Humanize(), contrast.Max.Difference),
            new(l["TimeSpent_Average_Title"], contrast.Average.Current.Humanize(), contrast.Average.Difference),
            new(l["TimeSpent_Total_Title"], contrast.Total.Current.Humanize(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.DeltaModel delta, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesser_Total"], delta.Tests.Current.ToMetric(), delta.Tests.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.ScoreContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesser_Score"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["History_EventGuesser_Points"], contrast.Points.Current.ToMetric(), contrast.Points.Difference),
            new(l["History_EventGuesser_x2Bonus"], contrast.Bonus.Current.ToMetric(), contrast.Bonus.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesser_Questions"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["History_EventGuesser_Correct"], contrast.Correct.Current.ToMetric(), contrast.Correct.Difference),
            new(l["History_EventGuesser_Incorrect"], contrast.Incorrect.Current.ToMetric(),
                contrast.Incorrect.Difference)
        };

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
