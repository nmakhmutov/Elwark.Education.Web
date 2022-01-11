namespace Education.Client.Gateways.Models.Progress;

public sealed record ScoreProgress(
    Contrast<ulong> Total,
    Contrast<uint> Questions,
    Contrast<uint> NoMistakes,
    Contrast<uint> Speed
);
