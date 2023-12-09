using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Course.Model;

public sealed record ExaminationInformationModel(
    DifficultyType Type,
    UserInventoryModel AccessInventory,
    bool IsAllowed
);
