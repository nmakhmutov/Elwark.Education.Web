namespace Education.Web.Client.Services.Model.Test;

public sealed record NumberOfTestsModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
