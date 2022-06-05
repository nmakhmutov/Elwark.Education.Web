using Education.Web.Gateways.Models;
using Education.Web.Gateways.Models.Inventory;
using Education.Web.Gateways.Models.Rule;

namespace Education.Web.Gateways.History.Tests.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TopicOverviewModel? Topic,
    TestInformation[] Tests,
    DescribedInventoryItemModel[] Inventories
);
