using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.DateGuesser.Model;

public sealed record DateGuesserBuilderModel(
    DateGuesserInformationModel[] Tests,
    UserInventoryModel[] Inventories
);
