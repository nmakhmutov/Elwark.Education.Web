using Education.Web.Gateways.Models.Inventory;
using Education.Web.Gateways.Models.Rule;

namespace Education.Web.Gateways.History.EventGuessers.Model;

public sealed record TestBuilderModel(TestRuleModel Rule, DescribedInventoryItemModel[] Inventory);
