using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record WeeklyDifferenceItem<T>(T Current, T Difference);

    public sealed record WeeklyDifference(
        WeeklyDifferenceItem<int> PassedTests,
        WeeklyDifferenceItem<long> Score,
        WeeklyDifferenceItem<int> Questions,
        WeeklyDifferenceItem<TimeSpan> TimeSpent
    );
}