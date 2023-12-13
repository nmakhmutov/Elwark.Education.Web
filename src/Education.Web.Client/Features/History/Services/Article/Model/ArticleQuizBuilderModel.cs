using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record ArticleQuizBuilderModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel? Activity,
    QuizInformationModel[] Quizzes,
    UserInventoryModel[] Inventories
);
