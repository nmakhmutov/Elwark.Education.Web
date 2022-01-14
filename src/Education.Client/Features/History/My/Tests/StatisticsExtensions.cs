using Education.Client.Extensions;
using Education.Client.Features.History.My.Tests.Components;
using Education.Client.Gateways.History.User;
using Education.Client.Gateways.Models.Statistics;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.My.Tests;

public static class StatisticsExtensions
{
    public static string RangeTitle(this TestRangeContrast contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static string RangeTitle(this EventGuesserRangeContrast contrast) =>
        RangeTitle(contrast.Starts, contrast.Ends);

    public static ProgressList.Item[] GetProgress(this NumberOfTestsContrast contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["NumberOfTests:Successful"], contrast.Successful.Current.ToReadable(), contrast.Successful.Difference),
            new(l["NumberOfTests:Failed"], contrast.Failed.Current.ToReadable(), contrast.Failed.Difference),
            new(l["NumberOfTests:MistakesExceeded"], contrast.MistakesExceeded.Current.ToReadable(),
                contrast.MistakesExceeded.Difference),
            new(l["NumberOfTests:TimeExceeded"], contrast.TimeExceeded.Current.ToReadable(),
                contrast.TimeExceeded.Difference),
            new(l["NumberOfTests:Total"], contrast.Total.Current.ToReadable(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this ScoreContrast contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Score:ByQuestions"], contrast.Questions.Current.ToReadable(), contrast.Questions.Difference),
            new(l["Score:BySpeedBonus"], contrast.Speed.Current.ToReadable(), contrast.Speed.Difference),
            new(l["Score:NoMistakesBonus"], contrast.NoMistakes.Current.ToReadable(), contrast.NoMistakes.Difference),
            new(l["Score:Total"], contrast.Total.Current.ToReadable(), contrast.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this AnswerRatioContrast contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Questions:Answered"], contrast.Answered.Current.ToReadable(), contrast.Answered.Difference),
            new(l["Questions:NotAnswered"], contrast.NotAnswered.Current.ToReadable(), contrast.NotAnswered.Difference),
            new(l["Questions:Correct"], contrast.Correct.Current.ToReadable(), contrast.Questions.Difference),
            new(l["Questions:Incorrect"], contrast.Incorrect.Current.ToReadable(), contrast.Incorrect.Difference),
            new(l["Questions:Total"], contrast.Questions.Current.ToReadable(), contrast.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(this TimeSpentContrast contrast, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent:Min"], contrast.Min.Current.ToSimpleFormat(), contrast.Min.Difference),
            new(l["TimeSpent:Max"], contrast.Max.Current.ToSimpleFormat(), contrast.Max.Difference),
            new(l["TimeSpent:Average"], contrast.Average.Current.ToSimpleFormat(), contrast.Average.Difference),
            new(l["TimeSpent:Total"], contrast.Total.Current.ToSimpleFormat(), contrast.Total.Difference)
        };

    private static string RangeTitle(DateTime starts, DateTime ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}
