using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizInformationModel(DifficultyType Type, UserInventoryModel AccessInventory, bool IsAllowed);
