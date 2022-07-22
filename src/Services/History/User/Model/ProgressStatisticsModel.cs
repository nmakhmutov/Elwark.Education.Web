using Education.Web.Services.Model.Statistics;

namespace Education.Web.Services.History.User.Model;

public sealed record ProgressStatisticsModel(
    ContrastModel<ulong> EasyTests,
    ContrastModel<ulong> HardTests,
    ContrastModel<ulong> MixedTests,
    ContrastModel<uint> EventGuessers,
    ProgressStatisticsModel.Progress[] Daily,
    ProgressStatisticsModel.Progress[] Monthly
)
{
    public sealed record Progress(
        DateOnly Date,
        uint Total,
        uint EasyTests,
        uint HardTests,
        uint MixedTests,
        uint EventGuessers
    );
}
