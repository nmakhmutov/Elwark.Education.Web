using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizAnswerModel(
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    AnswerResult Answer
);
