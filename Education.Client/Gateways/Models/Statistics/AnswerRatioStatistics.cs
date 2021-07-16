using System;

namespace Education.Client.Gateways.Models.Statistics
{
    public sealed record AnswerRatioStatistics(AnswerRatio Total, AnswerRatioProgress Progress);

    public sealed record AnswerRatioProgress(
        DateTime Starts,
        DateTime Ends,
        Contrast<uint> Questions,
        Contrast<uint> Answered,
        Contrast<uint> NotAnswered,
        Contrast<uint> Correct,
        Contrast<uint> Incorrect
    );
}
