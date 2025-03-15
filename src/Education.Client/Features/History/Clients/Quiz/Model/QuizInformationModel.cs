using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizInformationModel(
    AccessStatus Status,
    SubscriptionPlan RequiredSubscription,
    DifficultyType Difficulty,
    QuizInformationModel.QuestionModel Question,
    UserInventoryModel AccessInventory,
    Reward[] Rewards
)
{
    public sealed record QuestionModel(uint Quantity, uint AllowedMistakes, string[] Kinds);
}
