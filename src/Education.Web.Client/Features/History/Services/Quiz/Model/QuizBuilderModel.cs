using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Rule;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizBuilderModel(
    TestRuleModel Rule,
    UserArticleOverviewModel? Article,
    QuizInformationModel[] Tests,
    UserInventoryModel[] Inventories
);
