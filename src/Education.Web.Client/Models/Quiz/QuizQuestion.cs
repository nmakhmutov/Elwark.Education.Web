using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Models.Quiz;

public abstract record QuizQuestion(string Id, string Title, string? ImageUrl)
{
    public sealed record ShortModel(string Id, string Title, string? ImageUrl)
        : QuizQuestion(Id, Title, ImageUrl);

    public sealed record SingleModel(
        string Id,
        string Title,
        string? ImageUrl,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : QuizQuestion(Id, Title, ImageUrl);

    public sealed record MultipleModel(
        string Id,
        string Title,
        string? ImageUrl,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : QuizQuestion(Id, Title, ImageUrl);
}
