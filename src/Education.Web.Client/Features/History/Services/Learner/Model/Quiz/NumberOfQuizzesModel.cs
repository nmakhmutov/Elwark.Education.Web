namespace Education.Web.Client.Features.History.Services.Learner.Model.Quiz;

public sealed record NumberOfQuizzesModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
