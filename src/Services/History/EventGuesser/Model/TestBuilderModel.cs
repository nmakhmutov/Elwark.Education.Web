using Education.Web.Services.Model;
using Education.Web.Services.Model.Inventory;
using Education.Web.Services.Model.Rule;

namespace Education.Web.Services.History.EventGuesser.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TestInformationModel[] Tests,
    UserInventoryItemModel[] Inventory
);
