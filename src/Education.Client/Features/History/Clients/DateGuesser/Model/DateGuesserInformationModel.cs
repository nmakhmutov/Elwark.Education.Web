using Education.Client.Models;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserInformationModel(
    bool IsAllowed,
    DateGuesserSize Size,
    uint QuestionQuantity,
    UserInventoryModel AccessInventory,
    IEnumerable<InternalMoneyModel> Rewards
);
