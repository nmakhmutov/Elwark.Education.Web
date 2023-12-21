namespace Education.Client.Features.History.Clients.Learner.Model.Quiz;

public sealed record NumberOfQuizzesModel(
    uint Succeeded,
    uint Failed,
    uint TimeExceeded,
    uint MistakesExceeded,
    ulong Total
);
