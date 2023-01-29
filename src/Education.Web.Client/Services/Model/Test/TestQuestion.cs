using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.Model.Test;

public abstract record TestQuestion(string Id, string Title, string? Image, ArticleTitleModel Article)
{
    public sealed record ShortModel(string Id, string Title, string? Image, ArticleTitleModel Article)
        : TestQuestion(Id, Title, Image, Article);

    public sealed record SingleModel(
        string Id,
        string Title,
        string? Image,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : TestQuestion(Id, Title, Image, Article);

    public sealed record MultipleModel(
        string Id,
        string Title,
        string? Image,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : TestQuestion(Id, Title, Image, Article);
}
