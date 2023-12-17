using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Quiz.Request;

public sealed record CreateQuizRequest(DifficultyType Difficulty, EpochType Epoch);
