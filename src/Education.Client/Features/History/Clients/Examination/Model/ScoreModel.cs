namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ScoreModel(uint Questions, uint NoMistakes, uint Speed, ulong Total);
