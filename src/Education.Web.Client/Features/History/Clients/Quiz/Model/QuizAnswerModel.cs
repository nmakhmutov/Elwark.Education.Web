using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizAnswerModel(
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    AnswerResult Answer
);
