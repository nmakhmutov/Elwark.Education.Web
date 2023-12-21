using Education.Client.Models.Content;

namespace Education.Client.Models.Test;

public abstract record Question(string Id, string Title, string? ImageUrl)
{
    public sealed record ShortModel(string Id, string Title, string? ImageUrl)
        : Question(Id, Title, ImageUrl);

    public sealed record SingleModel(
        string Id,
        string Title,
        string? ImageUrl,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : Question(Id, Title, ImageUrl);

    public sealed record MultipleModel(
        string Id,
        string Title,
        string? ImageUrl,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : Question(Id, Title, ImageUrl);

    public sealed record OrderedModel(
        string Id,
        string Title,
        string? ImageUrl,
        ArticleTitleModel Article,
        AnswerOption[] Options
    ) : Question(Id, Title, ImageUrl);
}
