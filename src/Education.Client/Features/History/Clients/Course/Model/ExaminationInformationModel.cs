using Education.Client.Models.Inventory;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Course.Model;

public sealed record ExaminationInformationModel(
    DifficultyType Type,
    UserInventoryModel AccessInventory,
    bool IsAllowed
);
