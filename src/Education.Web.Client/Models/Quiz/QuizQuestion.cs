using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Models.Quiz;

public abstract record QuizQuestion(string Id, string Title, string? Image)
{
    public sealed record ShortModel(string Id, string Title, string? Image)
        : QuizQuestion(Id, Title, Image);

    public sealed record SingleModel(
        string Id,
        string Title,
        string? Image,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : QuizQuestion(Id, Title, Image);

    public sealed record MultipleModel(
        string Id,
        string Title,
        string? Image,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : QuizQuestion(Id, Title, Image);
}
