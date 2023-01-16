namespace Education.Web.Client.Services.History.User.Model.Test;

public sealed record NumberOfTestsModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
