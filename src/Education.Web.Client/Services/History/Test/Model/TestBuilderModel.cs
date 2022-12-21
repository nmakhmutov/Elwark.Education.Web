using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Rule;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TopicOverviewModel? Topic,
    TestInformationModel[] Tests,
    UserInventoryItemModel[] Inventories
);
