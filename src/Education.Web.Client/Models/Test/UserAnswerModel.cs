using System.Text.Json.Serialization;

namespace Education.Web.Client.Models.Test;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(ShortAnswerModel), "short"),
 JsonDerivedType(typeof(SingleAnswerModel), "single"),
 JsonDerivedType(typeof(MultipleAnswerModel), "multiple"),
 JsonDerivedType(typeof(OrderedAnswerModel), "ordered")]
public abstract record UserAnswerModel;

public sealed record ShortAnswerModel : UserAnswerModel
{
    public string Answer { get; set; } = string.Empty;
}

public sealed record SingleAnswerModel : UserAnswerModel
{
    public uint Answer { get; set; }
}

public sealed record MultipleAnswerModel : UserAnswerModel
{
    public List<uint> Answer { get; set; } = new();
}

public sealed record OrderedAnswerModel : UserAnswerModel
{
    public List<uint> Answer { get; set; } = new();
}
