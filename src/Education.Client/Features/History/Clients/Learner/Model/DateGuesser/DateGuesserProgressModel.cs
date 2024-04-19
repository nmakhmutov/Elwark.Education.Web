namespace Education.Client.Features.History.Clients.Learner.Model.DateGuesser;

public sealed record DateGuesserProgressModel(DateOnly Date, uint Small, uint Medium, uint Large);