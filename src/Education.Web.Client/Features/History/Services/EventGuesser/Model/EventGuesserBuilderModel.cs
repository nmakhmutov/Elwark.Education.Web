using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Rule;

namespace Education.Web.Client.Features.History.Services.EventGuesser.Model;

public sealed record EventGuesserBuilderModel(
    TestRuleModel Rule,
    EventGuesserInformationModel[] Tests,
    UserInventoryModel[] Inventory
);