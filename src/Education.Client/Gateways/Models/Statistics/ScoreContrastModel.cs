namespace Education.Client.Gateways.Models.Statistics;

public sealed record ScoreContrastModel(
    ContrastModel<ulong> Total,
    ContrastModel<uint> Questions,
    ContrastModel<uint> NoMistakes,
    ContrastModel<uint> Speed
);
