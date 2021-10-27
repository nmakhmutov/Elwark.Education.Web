using System;
using Education.Client.Extensions;
using Education.Client.Gateways.History.Me;
using Education.Client.Gateways.Models.Progress;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.My.Components;

public static class StatisticsExtensions
{
    public static string RangeTitle(this WeeklyProgress progress) =>
        RangeTitle(progress.Starts, progress.Ends);

    public static string RangeTitle(this EventGuesserProgress progress) =>
        RangeTitle(progress.Starts, progress.Ends);

    public static ProgressList.Item[] GetProgress(this NumberOfTestsProgress progress, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["NumberOfTests:Completed"], progress.Completed.Current.ToReadable(), progress.Completed.Difference),
            new(l["NumberOfTests:MistakesExceeded"], progress.MistakesExceeded.Current.ToReadable(),
                progress.MistakesExceeded.Difference),
            new(l["NumberOfTests:TimeExceeded"], progress.TimeExceeded.Current.ToReadable(),
                progress.TimeExceeded.Difference),
            new(l["NumberOfTests:Total"], progress.Total.Current.ToReadable(), progress.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this ScoreProgress progress, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Score:ByQuestions"], progress.Questions.Current.ToReadable(), progress.Questions.Difference),
            new(l["Score:BySpeedBonus"], progress.Speed.Current.ToReadable(), progress.Speed.Difference),
            new(l["Score:NoMistakesBonus"], progress.NoMistakes.Current.ToReadable(), progress.NoMistakes.Difference),
            new(l["Score:Total"], progress.Total.Current.ToReadable(), progress.Total.Difference)
        };

    public static ProgressList.Item[] GetProgress(this AnswerRatioProgress progress, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["Questions:Answered"], progress.Answered.Current.ToReadable(), progress.Answered.Difference),
            new(l["Questions:NotAnswered"], progress.NotAnswered.Current.ToReadable(), progress.NotAnswered.Difference),
            new(l["Questions:Correct"], progress.Correct.Current.ToReadable(), progress.Questions.Difference),
            new(l["Questions:Incorrect"], progress.Incorrect.Current.ToReadable(), progress.Incorrect.Difference),
            new(l["Questions:Total"], progress.Questions.Current.ToReadable(), progress.Questions.Difference)
        };

    public static ProgressList.Item[] GetProgress(this TimeSpentProgress progress, IStringLocalizer<App> l) =>
        new ProgressList.Item[]
        {
            new(l["TimeSpent:Min"], progress.Min.Current.ToLongFormat(), progress.Min.Difference),
            new(l["TimeSpent:Max"], progress.Max.Current.ToLongFormat(), progress.Max.Difference),
            new(l["TimeSpent:Average"], progress.Average.Current.ToLongFormat(), progress.Average.Difference),
            new(l["TimeSpent:Total"], progress.Total.Current.ToLongFormat(), progress.Total.Difference)
        };

    private static string RangeTitle(DateTime starts, DateTime ends) =>
        $"{starts:dd MMM} ― {ends:dd MMM}";
}