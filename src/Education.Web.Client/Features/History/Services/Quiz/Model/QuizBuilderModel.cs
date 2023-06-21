using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record QuizBuilderModel(
    QuizInformationModel[] Quizzes,
    UserInventoryModel[] Inventories,
    UserArticleOverviewModel? Article
);
