namespace Education.Web.Client.Features.History.Services.User.Model.Test;

public sealed record NumberOfTestsModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
