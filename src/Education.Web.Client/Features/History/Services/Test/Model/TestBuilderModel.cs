using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Rule;

namespace Education.Web.Client.Features.History.Services.Test.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    UserArticleOverviewModel? Article,
    TestInformationModel[] Tests,
    UserInventoryModel[] Inventories
);
