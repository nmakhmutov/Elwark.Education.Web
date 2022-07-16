using Education.Web.Extensions;
using Education.Web.Gateways.History.Users.Model;
using Education.Web.Gateways.Models.Statistics;
using Education.Web.Pages.History.My.Tests.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Pages.History.My.Tests;

public static class StatisticsExtensions
{
    public static string RangeTitle(this TestRangeContrastModel contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static string RangeTitle(this EventGuesserStatisticsModel.Contrast contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static ProgressList.Item[] GetProgress(this NumberOfTestsContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["NumberOfTests:Successful"], contrast.Successful.Current.ToReadable(), contrast.Successful.Difference),
            new(l["NumberOfTests:Failed"], contrast.Failed.Current.ToReadable(), contrast.Failed.Difference),
            new(l["NumberOfTests:MistakesExceeded"], contrast.MistakesExceeded.Current.ToReadable(), contrast.MistakesExceeded.Difference),
            new(l["NumberOfTests:TimeExceeded"], contrast.TimeExceeded.Current.ToReadable(), contrast.TimeExceeded.Difference),
            new(l["NumberOfTests:Total"], contrast.Total.Current.ToReadable(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this ScoreContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Score:ByQuestions"], contrast.Questions.Current.ToReadable(), contrast.Questions.Difference),
            new(l["Score:BySpeedBonus"], contrast.Speed.Current.ToReadable(), contrast.Speed.Difference),
            new(l["Score:NoMistakesBonus"], contrast.NoMistakes.Current.ToReadable(), contrast.NoMistakes.Difference),
            new(l["Score:Total"], contrast.Total.Current.ToReadable(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this AnswerRatioContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Questions:Answered"], contrast.Answered.Current.ToReadable(), contrast.Answered.Difference),
            new(l["Questions:NotAnswered"], contrast.NotAnswered.Current.ToReadable(), contrast.NotAnswered.Difference),
            new(l["Questions:Correct"], contrast.Correct.Current.ToReadable(), contrast.Questions.Difference),
            new(l["Questions:Incorrect"], contrast.Incorrect.Current.ToReadable(), contrast.Incorrect.Difference),
            new(l["Questions:Total"], contrast.Questions.Current.ToReadable(), contrast.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(this TimeSpentContrastModel contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent:Min"], contrast.Min.Current.ToSimpleFormat(), contrast.Min.Difference),
            new(l["TimeSpent:Max"], contrast.Max.Current.ToSimpleFormat(), contrast.Max.Difference),
            new(l["TimeSpent:Average"], contrast.Average.Current.ToSimpleFormat(), contrast.Average.Difference),
            new(l["TimeSpent:Total"], contrast.Total.Current.ToSimpleFormat(), contrast.Total.Difference)
        };

    private static string RangeTitle(DateOnly starts, DateOnly ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
