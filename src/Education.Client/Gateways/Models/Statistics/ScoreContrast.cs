namespace Education.Client.Gateways.Models.Statistics;

public sealed record ScoreContrast(
    Contrast<ulong> Total,
    Contrast<uint> Questions,
    Contrast<uint> NoMistakes,
    Contrast<uint> Speed
);
