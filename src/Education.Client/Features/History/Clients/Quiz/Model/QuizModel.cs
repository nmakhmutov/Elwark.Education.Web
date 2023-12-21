using Education.Client.Models.Content;
using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizModel(
    string Id,
    DifficultyType Type,
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    DateTime ExpiredAt,
    ArticleTitleModel Article,
    Question Question,
    TestInventoryModel[] Inventory
);
