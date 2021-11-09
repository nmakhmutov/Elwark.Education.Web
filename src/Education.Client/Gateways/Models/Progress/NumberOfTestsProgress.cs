namespace Education.Client.Gateways.Models.Progress;

public sealed record NumberOfTestsProgress(
    Contrast<uint> Successful,
    Contrast<uint> Failed,
    Contrast<uint> TimeExceeded,
    Contrast<uint> MistakesExceeded,
    Contrast<ulong> Total
);
