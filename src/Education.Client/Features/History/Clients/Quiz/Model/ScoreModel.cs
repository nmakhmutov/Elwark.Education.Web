namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record ScoreModel(uint Questions, uint NoMistakes, uint Speed, ulong Total);
