namespace Education.Web.Services.Model.Test;

public abstract record AnswerToQuestionModel(string Type);

public sealed record ShortAnswerModel() : AnswerToQuestionModel("short")
{
    public string Answer { get; set; } = string.Empty;
}

public sealed record SingleAnswerModel() : AnswerToQuestionModel("single")
{
    public uint Answer { get; set; }
}

public sealed record MultipleAnswerModel() : AnswerToQuestionModel("multiple")
{
    public List<uint> Answer { get; set; } = new();
}
