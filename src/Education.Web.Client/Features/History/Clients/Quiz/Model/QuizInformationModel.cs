using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Quiz.Model;

public sealed record QuizInformationModel(DifficultyType Type, UserInventoryModel AccessInventory, bool IsAllowed);
