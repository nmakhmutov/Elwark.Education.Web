using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.User;

public sealed record ProgressStatistics(
    Contrast<ulong> EasyTests,
    Contrast<ulong> HardTests,
    Contrast<ulong> MixedTests,
    Contrast<uint> EventGuessers,
    ProgressStatistics.Progress[] Daily,
    ProgressStatistics.Progress[] Monthly
)
{
    public sealed record Progress(
        DateTime Date,
        uint Total,
        uint EasyTests,
        uint HardTests,
        uint MixedTests,
        uint EventGuessers
    );
}
