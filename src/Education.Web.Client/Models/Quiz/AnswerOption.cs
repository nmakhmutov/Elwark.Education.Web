namespace Education.Web.Client.Models.Quiz;

public abstract record AnswerOption(uint Id)
{
    public sealed record TextModel(uint Id, string Text)
        : AnswerOption(Id);

    public sealed record ImageModel(uint Id, string Image)
        : AnswerOption(Id);
}
