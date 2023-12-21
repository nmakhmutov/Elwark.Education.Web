using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record ArticleQuizBuilderModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel? Activity,
    QuizInformationModel[] Quizzes,
    UserInventoryModel[] Inventories
);
