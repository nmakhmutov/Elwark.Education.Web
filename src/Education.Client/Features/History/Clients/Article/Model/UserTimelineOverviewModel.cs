namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record UserTimelineOverviewModel(
    TimelineOverviewModel Article,
    UserArticleActivityModel? Activity,
    bool HasQuiz
);
