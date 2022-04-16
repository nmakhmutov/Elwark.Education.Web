namespace Education.Web.Gateways.Models.Test;

public abstract record AnswerToQuestionModel;

public sealed record ShortAnswerModel : AnswerToQuestionModel
{
    public string ShortAnswer { get; set; } = string.Empty;
}

public sealed record SingleAnswerModel : AnswerToQuestionModel
{
    public uint SingleAnswer { get; set; }
}

public sealed record MultipleAnswerModel : AnswerToQuestionModel
{
    public List<uint> MultipleAnswer { get; set; } = new();
}
