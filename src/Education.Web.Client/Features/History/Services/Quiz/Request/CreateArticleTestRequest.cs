using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Request;

public sealed record CreateArticleTestRequest(QuizType Type, string ArticleId);
