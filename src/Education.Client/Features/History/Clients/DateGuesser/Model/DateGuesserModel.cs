using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserModel(
    string Id,
    DateTime X2BonusUntil,
    ScoreModel Score,
    DateGuesserSize Size,
    uint CompletedQuestions,
    uint TotalQuestions,
    DateGuesserModel.QuestionModel Question,
    TestInventoryModel[] Inventory
)
{
    public sealed record QuestionModel(string Id, string Title);
}
