using Education.Client.Gateways.Models.Inventory;
using Education.Client.Gateways.Models.Rule;

namespace Education.Client.Gateways.History.Tests.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    TopicOverviewModel? Topic,
    DescribedInventoryItemModel[] Inventory
);
