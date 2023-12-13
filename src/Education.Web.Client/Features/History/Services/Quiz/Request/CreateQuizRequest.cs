using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Request;

public sealed record CreateQuizRequest(DifficultyType Difficulty, EpochType Epoch);
