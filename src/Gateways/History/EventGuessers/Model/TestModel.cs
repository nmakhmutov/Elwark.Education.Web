using Education.Web.Gateways.Models.Inventory;

namespace Education.Web.Gateways.History.EventGuessers.Model;

public sealed record TestModel(
    string Id,
    DateTime X2BonusUntil,
    uint Score,
    uint CompletedQuestions,
    uint TotalQuestions,
    TestModel.QuestionModel? Question,
    TestInventoryItemModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
