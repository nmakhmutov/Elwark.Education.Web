namespace Education.Client.Features.History.Clients.Learner.Model.Examination;

public sealed record AnswerRatioModel(uint Questions, uint Answered, uint NotAnswered, uint Correct, uint Incorrect);
