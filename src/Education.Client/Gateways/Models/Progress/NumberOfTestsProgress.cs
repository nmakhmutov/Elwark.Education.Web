namespace Education.Client.Gateways.Models.Progress;

public sealed record NumberOfTestsProgress(
    Contrast<uint> Total,
    Contrast<uint> Completed,
    Contrast<uint> TimeExceeded,
    Contrast<uint> MistakesExceeded
);