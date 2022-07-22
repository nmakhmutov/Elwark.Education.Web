using Education.Web.Services.Model;
using Education.Web.Services.Model.Inventory;
using Education.Web.Services.Model.Rule;

namespace Education.Web.Services.History.Test.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TopicOverviewModel? Topic,
    TestInformationModel[] Tests,
    UserInventoryItemModel[] Inventories
);
