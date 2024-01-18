using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizModel(
    string TestId,
    string ArticleId,
    string Title,
    DifficultyType Difficulty,
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    DateTime ExpiredAt,
    Question Question,
    TestInventoryModel[] Inventory
);
