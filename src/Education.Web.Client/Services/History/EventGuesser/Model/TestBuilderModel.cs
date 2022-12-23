using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Rule;

namespace Education.Web.Client.Services.History.EventGuesser.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TestInformationModel[] Tests,
    UserInventoryModel[] Inventory
);
