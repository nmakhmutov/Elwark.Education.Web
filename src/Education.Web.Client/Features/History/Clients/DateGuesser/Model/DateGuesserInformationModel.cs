using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserInformationModel(
    DateGuesserType Type,
    UserInventoryModel AccessInventory,
    bool IsAllowed
);
