namespace Education.Web.Gateways.Models.Test;

public abstract record AnswerToQuestionModel;

public sealed record ShortAnswerToQuestionModel : AnswerToQuestionModel
{
    public string ShortAnswer { get; set; } = string.Empty;
}

public sealed record SingleAnswerToQuestionModel : AnswerToQuestionModel
{
    public uint SingleAnswer { get; set; }
}

public sealed record MultipleAnswerToQuestionModel : AnswerToQuestionModel
{
    public List<uint> MultipleAnswer { get; set; } = new();
}
