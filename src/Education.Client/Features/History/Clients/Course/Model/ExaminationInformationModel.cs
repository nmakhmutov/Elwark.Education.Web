using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Course.Model;

public sealed record ExaminationInformationModel(
    bool IsAllowed,
    DifficultyType Difficulty,
    ExaminationInformationModel.QuestionModel Question,
    UserInventoryModel AccessInventory,
    Reward[] Rewards
)
{
    public sealed record QuestionModel(uint Quantity, string[] Kinds);
}
