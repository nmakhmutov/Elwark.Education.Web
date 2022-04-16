using Education.Web.Gateways.Models.Inventory;

namespace Education.Web.Gateways.History.EventGuesser.Model;

public sealed record TestModel(
    string Id,
    DateTime X2BonusUntil,
    uint Score,
    uint CompletedQuestions,
    uint TotalQuestions,
    TestModel.QuestionModel? Question,
    DescribedInventoryItemModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
