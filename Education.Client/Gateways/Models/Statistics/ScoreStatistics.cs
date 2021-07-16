using System;

namespace Education.Client.Gateways.Models.Statistics
{
    public sealed record ScoreStatistics(Score Total, ScoreProgress Progress);

    public sealed record ScoreProgress(
        DateTime Starts,
        DateTime Ends,
        Contrast<ulong> Total,
        Contrast<uint> Questions,
        Contrast<uint> NoMistakes,
        Contrast<uint> Speed
    );
}
