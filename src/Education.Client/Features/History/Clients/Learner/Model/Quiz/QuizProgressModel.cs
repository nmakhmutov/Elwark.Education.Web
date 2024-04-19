namespace Education.Client.Features.History.Clients.Learner.Model.Quiz;

public sealed record QuizProgressModel(DateOnly Date, uint Easy, uint Hard);