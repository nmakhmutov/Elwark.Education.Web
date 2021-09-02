using System;

namespace Education.Client.Gateways.Models.Progress
{
    public sealed record TimeSpentProgress(
        Contrast<TimeSpan> Total,
        Contrast<TimeSpan> Average,
        Contrast<TimeSpan> Min,
        Contrast<TimeSpan> Max
    );
}
