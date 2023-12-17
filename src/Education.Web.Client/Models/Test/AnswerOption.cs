namespace Education.Web.Client.Models.Test;

public abstract record AnswerOption(uint Id)
{
    public sealed record TextModel(uint Id, string Text)
        : AnswerOption(Id);

    public sealed record ImageModel(uint Id, string ImageUrl)
        : AnswerOption(Id);
}
