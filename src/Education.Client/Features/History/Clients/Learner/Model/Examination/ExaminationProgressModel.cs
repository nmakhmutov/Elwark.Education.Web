namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record ExaminationProgressModel(DateOnly Date, uint Easy, uint Hard);
