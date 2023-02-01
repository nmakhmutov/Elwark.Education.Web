using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Rule;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    UserArticleOverviewModel? Article,
    TestInformationModel[] Tests,
    UserInventoryModel[] Inventories
);
