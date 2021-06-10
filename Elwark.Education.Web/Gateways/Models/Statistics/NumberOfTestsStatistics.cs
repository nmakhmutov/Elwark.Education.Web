using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record NumberOfTestsStatistics(NumberOfTests Total, NumberOfTestsProgress Progress);

    public sealed record NumberOfTestsProgress(
        DateTime Starts,
        DateTime Ends,
        Contrast<uint> Total,
        Contrast<uint> Completed,
        Contrast<uint> TimeExceeded,
        Contrast<uint> MistakesExceeded
    );
}
