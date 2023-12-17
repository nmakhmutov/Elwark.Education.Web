using Education.Web.Client.Models.Content;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Quiz.Model;

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
