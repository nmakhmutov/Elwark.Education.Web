using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserModel(
    string Id,
    DateTime X2BonusUntil,
    ScoreModel Score,
    uint CompletedQuestions,
    uint TotalQuestions,
    DateGuesserModel.QuestionModel? Question,
    TestInventoryModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
