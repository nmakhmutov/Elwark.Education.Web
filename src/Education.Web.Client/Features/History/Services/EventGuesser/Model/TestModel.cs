using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.EventGuesser.Model;

public sealed record TestModel(
    string Id,
    DateTime X2BonusUntil,
    ScoreModel Score,
    uint CompletedQuestions,
    uint TotalQuestions,
    TestModel.QuestionModel? Question,
    TestInventoryModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
