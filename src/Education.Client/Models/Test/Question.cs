namespace Education.Client.Models.Test;

public abstract record Question(string Id, string Title, string? ImageUrl)
{
    public sealed record TextModel(string Id, string Title, string? ImageUrl) :
        Question(Id, Title, ImageUrl);

    public sealed record SingleModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);

    public sealed record MultiModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);

    public sealed record OrderingModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);
}
