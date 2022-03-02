namespace Education.Web.Gateways.Models.Statistics;

public sealed record NumberOfTestsContrastModel(
    ContrastModel<uint> Successful,
    ContrastModel<uint> Failed,
    ContrastModel<uint> TimeExceeded,
    ContrastModel<uint> MistakesExceeded,
    ContrastModel<ulong> Total
);
