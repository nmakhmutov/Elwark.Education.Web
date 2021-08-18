using System;
using Education.Client.Gateways.Models.Statistics;
using Education.Client.Infrastructure.Extensions;
using Microsoft.Extensions.Localization;

namespace Education.Client.Pages.History.Profile.Statistics
{
    public static class StatisticsExtensions
    {
        public static string RangeTitle(this NumberOfTestsProgress progress) =>
            RangeTitle(progress.Starts, progress.Ends);

        public static string RangeTitle(this ScoreProgress progress) =>
            RangeTitle(progress.Starts, progress.Ends);

        public static string RangeTitle(this TimeSpentProgress progress) =>
            RangeTitle(progress.Starts, progress.Ends);

        public static string RangeTitle(this AnswerRatioProgress progress) =>
            RangeTitle(progress.Starts, progress.Ends);

        public static ProgressList.Item[] GetProgress(this NumberOfTestsProgress progress, IStringLocalizer<App> l) =>
            new ProgressList.Item[]
            {
                new(l["NumberOfTests:Completed"], progress.Completed.Current.ToReadable(), progress.Completed.Difference),
                new(l["NumberOfTests:MistakesExceeded"], progress.MistakesExceeded.Current.ToReadable(), progress.MistakesExceeded.Difference),
                new(l["NumberOfTests:TimeExceeded"], progress.TimeExceeded.Current.ToReadable(), progress.TimeExceeded.Difference),
                new(l["NumberOfTests:Total"], progress.Total.Current.ToReadable(), progress.Total.Difference),
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
                new(l["TimeSpent"], progress.TimeSpent.Current.ToLongFormat(), progress.TimeSpent.Difference)
            };

        private static string RangeTitle(DateTime starts, DateTime ends) =>
            $"{starts:dd MMM} ― {ends:dd MMM}";
    }
}
