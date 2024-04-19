namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record NumberOfExaminationsModel(uint Succeeded, uint Failed, uint TimeExceeded, uint Total);
