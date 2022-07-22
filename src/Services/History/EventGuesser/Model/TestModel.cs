using Education.Web.Services.Model.Inventory;

namespace Education.Web.Services.History.EventGuesser.Model;

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
