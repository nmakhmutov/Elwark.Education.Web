using Education.Web.Client.Features.History.Clients.Quiz.Model;
using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Clients.Article.Model;

public sealed record ArticleQuizBuilderModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel? Activity,
    QuizInformationModel[] Quizzes,
    UserInventoryModel[] Inventories
);
