using System.Text.Json.Serialization;

namespace Education.Web.Client.Models.Quiz;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(ShortAnswerModel), "short"),
 JsonDerivedType(typeof(SingleAnswerModel), "single"),
 JsonDerivedType(typeof(MultipleAnswerModel), "multiple")]
public abstract record AnswerToQuestionModel;

public sealed record ShortAnswerModel : AnswerToQuestionModel
{
    public string Answer { get; set; } = string.Empty;
}

public sealed record SingleAnswerModel : AnswerToQuestionModel
{
    public uint Answer { get; set; }
}

public sealed record MultipleAnswerModel : AnswerToQuestionModel
{
    public List<uint> Answer { get; set; } = new();
}
