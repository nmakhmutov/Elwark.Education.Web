using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserInformationModel(
    AccessStatus Status,
    SubscriptionPlan RequiredSubscription,
    DateGuesserSize Size,
    uint QuestionQuantity,
    UserInventoryModel AccessInventory,
    Reward[] Rewards
);
