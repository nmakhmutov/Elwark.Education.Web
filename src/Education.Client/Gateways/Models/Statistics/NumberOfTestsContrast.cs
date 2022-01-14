namespace Education.Client.Gateways.Models.Statistics;

public sealed record NumberOfTestsContrast(
    Contrast<uint> Successful,
    Contrast<uint> Failed,
    Contrast<uint> TimeExceeded,
    Contrast<uint> MistakesExceeded,
    Contrast<ulong> Total
);
