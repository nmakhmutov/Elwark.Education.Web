using Education.Client.Models.Content;
using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Examination.Model;

public sealed record ExaminationModel(
    string Id,
    DifficultyType Difficulty,
    uint CompletedQuestions,
    uint TotalQuestions,
    bool IsCompleted,
    DateTime ExpiredAt,
    CourseTitleModel Course,
    Question Question,
    TestInventoryModel[] Inventory
);
