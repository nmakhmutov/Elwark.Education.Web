using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Components.Lists;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Quiz;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My;

public static class StatisticsExtensions
{
    public static string RangeTitle(this QuizStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static string RangeTitle(this EventGuesserStatisticsModel.DeltaModel delta) =>
        RangeTitle(delta.Start, delta.End);

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.NumberOfQuizzesContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Shared_NumberOfSuccessfulQuizzes"], contrast.Successful.Current.ToMetric(), contrast.Successful.Difference),
            new(l["Shared_NumberOfFailedQuizzes"], contrast.Failed.Current.ToMetric(), contrast.Failed.Difference),
            new(l["Shared_NumberOfMistakesExceededQuizzes"], contrast.MistakesExceeded.Current.ToMetric(), contrast.MistakesExceeded.Difference),
            new(l["Shared_NumberOfTimeExceededQuizzes"], contrast.TimeExceeded.Current.ToMetric(), contrast.TimeExceeded.Difference),
            new(l["Shared_NumberOfTotalQuizzes"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.ScoreContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Score:ByQuestions"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Score:BySpeedBonus"], contrast.Speed.Current.ToMetric(), contrast.Speed.Difference),
            new(l["Score:NoMistakesBonus"], contrast.NoMistakes.Current.ToMetric(), contrast.NoMistakes.Difference),
            new(l["Score:Total"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Questions:Answered"], contrast.Answered.Current.ToMetric(), contrast.Answered.Difference),
            new(l["Questions:NotAnswered"], contrast.NotAnswered.Current.ToMetric(), contrast.NotAnswered.Difference),
            new(l["Questions:Correct"], contrast.Correct.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Questions:Incorrect"], contrast.Incorrect.Current.ToMetric(), contrast.Incorrect.Difference),
            new(l["Questions:Total"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this QuizStatisticsModel.TimeSpentContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent:Min"], contrast.Min.Current.Humanize(), contrast.Min.Difference),
            new(l["TimeSpent:Max"], contrast.Max.Current.Humanize(), contrast.Max.Difference),
            new(l["TimeSpent:Average"], contrast.Average.Current.Humanize(), contrast.Average.Difference),
            new(l["TimeSpent:Total"], contrast.Total.Current.Humanize(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.DeltaModel delta, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesserTotal"], delta.Tests.Current.ToMetric(), delta.Tests.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.ScoreContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesserScore"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["History_EventGuesserPoints"], contrast.Points.Current.ToMetric(), contrast.Points.Difference),
            new(l["History_EventGuesserBonus"], contrast.Bonus.Current.ToMetric(), contrast.Bonus.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["History_EventGuesserQuestions"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["History_EventGuesserCorrect"], contrast.Correct.Current.ToMetric(), contrast.Correct.Difference),
            new(l["History_EventGuesserIncorrect"], contrast.Incorrect.Current.ToMetric(), contrast.Incorrect.Difference)
        };

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
