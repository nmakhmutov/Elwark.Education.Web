using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record UserArticleDetailModel(
    ArticleDetail Article,
    UserArticleActivityModel? Activity,
    DifficultyType[] Difficulties
);
