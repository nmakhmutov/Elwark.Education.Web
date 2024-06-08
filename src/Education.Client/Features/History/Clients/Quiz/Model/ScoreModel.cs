namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record ScoreModel(uint Questions, uint AccuracyBonus, uint TimeBonus, ulong Total);
