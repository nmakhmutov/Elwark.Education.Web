using System;
using Education.Client.Gateways.Models.Progress;

namespace Education.Client.Gateways.History.User;

public sealed record EventGuesserStatistics(
    uint Tests,
    uint Score,
    uint Points,
    uint Bonus,
    uint Questions,
    uint Correct,
    uint Incorrect,
    EventGuesserProgress Progress
);

public sealed record EventGuesserProgress(
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
