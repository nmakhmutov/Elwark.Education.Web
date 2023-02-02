using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Components.Lists;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Test;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.My;

public static class StatisticsExtensions
{
    public static string RangeTitle(this TestStatisticsModel.ContrastModel contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static string RangeTitle(this EventGuesserStatisticsModel.ContrastModel contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static ProgressList.Item[] GetProgress(
        this TestStatisticsModel.NumberOfTestsContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["NumberOfTests:Successful"], contrast.Successful.Current.ToMetric(), contrast.Successful.Difference),
            new(l["NumberOfTests:Failed"], contrast.Failed.Current.ToMetric(), contrast.Failed.Difference),
            new(l["NumberOfTests:MistakesExceeded"], contrast.MistakesExceeded.Current.ToMetric(), contrast.MistakesExceeded.Difference),
            new(l["NumberOfTests:TimeExceeded"], contrast.TimeExceeded.Current.ToMetric(), contrast.TimeExceeded.Difference),
            new(l["NumberOfTests:Total"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this TestStatisticsModel.ScoreContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Score:ByQuestions"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Score:BySpeedBonus"], contrast.Speed.Current.ToMetric(), contrast.Speed.Difference),
            new(l["Score:NoMistakesBonus"], contrast.NoMistakes.Current.ToMetric(), contrast.NoMistakes.Difference),
            new(l["Score:Total"], contrast.Total.Current.ToMetric(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this TestStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Questions:Answered"], contrast.Answered.Current.ToMetric(), contrast.Answered.Difference),
            new(l["Questions:NotAnswered"], contrast.NotAnswered.Current.ToMetric(), contrast.NotAnswered.Difference),
            new(l["Questions:Correct"], contrast.Correct.Current.ToMetric(), contrast.Questions.Difference),
            new(l["Questions:Incorrect"], contrast.Incorrect.Current.ToMetric(), contrast.Incorrect.Difference),
            new(l["Questions:Total"], contrast.Questions.Current.ToMetric(), contrast.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this TestStatisticsModel.TimeSpentContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent:Min"], contrast.Min.Current.Humanize(), contrast.Min.Difference),
            new(l["TimeSpent:Max"], contrast.Max.Current.Humanize(), contrast.Max.Difference),
            new(l["TimeSpent:Average"], contrast.Average.Current.Humanize(), contrast.Average.Difference),
            new(l["TimeSpent:Total"], contrast.Total.Current.Humanize(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.ContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Tests"], contrast.Tests.Current.ToMetric(), contrast.Tests.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.ScoreContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["EventGuesser:Score"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["EventGuesser:Points"], contrast.Points.Current.ToMetric(), contrast.Points.Difference),
            new(l["EventGuesser:Bonus"], contrast.Bonus.Current.ToMetric(), contrast.Bonus.Difference)
        };

    public static ProgressList.Item[] GetProgress(
        this EventGuesserStatisticsModel.AnswerRatioContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["EventGuesser:Questions"], contrast.Total.Current.ToMetric(), contrast.Total.Difference),
            new(l["EventGuesser:Correct"], contrast.Correct.Current.ToMetric(), contrast.Correct.Difference),
            new(l["EventGuesser:Incorrect"], contrast.Incorrect.Current.ToMetric(), contrast.Incorrect.Difference)
        };

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
