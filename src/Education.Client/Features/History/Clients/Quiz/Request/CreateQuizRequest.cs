using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Request;

public sealed record CreateQuizRequest(DifficultyType Difficulty, EpochType Epoch);
