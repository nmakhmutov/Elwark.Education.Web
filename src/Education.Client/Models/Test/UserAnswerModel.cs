using System.Text.Json.Serialization;

namespace Education.Client.Models.Test;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(TextAnswerModel), "text"),
 JsonDerivedType(typeof(SingleAnswerModel), "single"),
 JsonDerivedType(typeof(MultipleAnswerModel), "multiple"),
 JsonDerivedType(typeof(OrderingAnswerModel), "ordering")]
public abstract record UserAnswerModel;

public sealed record TextAnswerModel : UserAnswerModel
{
    public string Answer { get; set; } = string.Empty;
}

public sealed record SingleAnswerModel : UserAnswerModel
{
    public uint Answer { get; set; }
}

public sealed record MultipleAnswerModel : UserAnswerModel
{
    public List<uint> Answer { get; set; } = [];
}

public sealed record OrderingAnswerModel : UserAnswerModel
{
    public List<uint> Answer { get; set; } = [];
}
