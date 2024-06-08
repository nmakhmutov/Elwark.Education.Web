namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ScoreModel(uint Questions, uint AccuracyBonus, uint TimeBonus, ulong Total);
