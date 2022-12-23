using Education.Web.Client.Services.Model.Inventory;

namespace Education.Web.Client.Services.History.EventGuesser.Model;

public sealed record TestModel(
    string Id,
    DateTime X2BonusUntil,
    uint Score,
    uint CompletedQuestions,
    uint TotalQuestions,
    TestModel.QuestionModel? Question,
    TestInventoryModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
