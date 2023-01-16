namespace Education.Web.Client.Services.Model.Test;

public abstract record AnswerOptionModel(uint Id)
{
    public sealed record TextAnswerOptionModel(uint Id, string Text)
        : AnswerOptionModel(Id);

    public sealed record ImageAnswerOptionModel(uint Id, string Image)
        : AnswerOptionModel(Id);
}
