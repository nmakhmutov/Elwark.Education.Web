using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserInformationModel(
    DateGuesserType Type,
    UserInventoryModel AccessInventory,
    bool IsAllowed
);
