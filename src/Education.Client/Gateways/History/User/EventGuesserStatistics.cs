using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.User;

public sealed record EventGuesserStatistics(
    uint Tests,
    uint Score,
    uint Points,
    uint Bonus,
    uint Questions,
    uint Correct,
    uint Incorrect,
    EventGuesserRangeContrast RangeContrast
);

public sealed record EventGuesserRangeContrast(
    DateTime Starts,
    DateTime Ends,
    Contrast<uint> Tests,
    Contrast<uint> Score,
    Contrast<uint> Bonus,
    Contrast<uint> Points,
    Contrast<uint> Questions,
    Contrast<uint> Correct,
    Contrast<uint> Incorrect
);
