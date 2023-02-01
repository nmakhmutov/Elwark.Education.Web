using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Rule;

namespace Education.Web.Client.Services.History.EventGuesser.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TestInformationModel[] Tests,
    UserInventoryModel[] Inventory
);
