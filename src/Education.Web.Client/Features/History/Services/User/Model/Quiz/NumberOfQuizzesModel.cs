namespace Education.Web.Client.Features.History.Services.User.Model.Quiz;

public sealed record NumberOfQuizzesModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
