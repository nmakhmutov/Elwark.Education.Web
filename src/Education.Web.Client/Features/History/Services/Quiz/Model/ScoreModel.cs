namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record ScoreModel(uint Questions, uint NoMistakes, uint Speed, ulong Total);
