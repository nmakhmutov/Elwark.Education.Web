using System;
using Education.Client.Gateways.Models.Progress;

namespace Education.Client.Gateways.History.User;

public sealed record ActivityStatistics(
    Contrast<ulong> EasyTests,
    Contrast<ulong> HardTests,
    Contrast<ulong> MixedTests,
    Contrast<uint> EventGuessers,
    ActivityStatistics.Statistics[] Daily,
    ActivityStatistics.Statistics[] Monthly
)
{
    public sealed record Statistics(
        DateTime Date,
        uint Total,
        uint EasyTests,
        uint HardTests,
        uint MixedTests,
        uint EventGuessers
    );
}
