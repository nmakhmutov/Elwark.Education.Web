namespace Education.Client.Gateways.Models.Test;

public sealed record NumberOfTestsModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
