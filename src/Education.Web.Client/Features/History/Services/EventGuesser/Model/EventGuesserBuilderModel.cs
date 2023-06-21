using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.EventGuesser.Model;

public sealed record EventGuesserBuilderModel(
    EventGuesserInformationModel[] Tests,
    UserInventoryModel[] Inventory
);