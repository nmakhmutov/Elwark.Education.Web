using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ExaminationModel(
    string TestId,
    string CourseId,
    string Title,
    DifficultyType Difficulty,
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    DateTime ExpiredAt,
    Question Question,
    TestInventoryModel[] Inventory
);
