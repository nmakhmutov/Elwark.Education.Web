using Education.Client.Models;
using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizInformationModel(
    bool IsAllowed,
    DifficultyType Difficulty,
    QuizInformationModel.QuestionModel Question,
    UserInventoryModel AccessInventory,
    IEnumerable<InternalMoneyModel> Rewards
)
{
    public sealed record QuestionModel(uint Quantity, uint AllowedMistakes, IEnumerable<string> Kinds);
}
