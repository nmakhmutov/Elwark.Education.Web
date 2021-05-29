using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TimeSpentStatistics(TimeSpan Total, TimeSpentProgress Progress);

    public sealed record TimeSpentProgress(DateTime Starts, DateTime Ends, Contrast<TimeSpan> TimeSpent);
}
