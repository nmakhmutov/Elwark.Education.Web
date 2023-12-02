using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz.Request;

public sealed record CreateArticleQuizRequest(DifficultyType Difficulty, string ArticleId);
