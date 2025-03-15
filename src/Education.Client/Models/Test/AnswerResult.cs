using System.Text.Json.Serialization;

namespace Education.Client.Models.Test;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(TextModel), "text"),
 JsonDerivedType(typeof(SingleModel), "single"),
 JsonDerivedType(typeof(MultipleModel), "multiple"),
 JsonDerivedType(typeof(OrderingModel), "ordering")]
public abstract record AnswerResult(bool IsCorrect)
{
    public sealed record TextModel(bool IsCorrect, string Answer)
        : AnswerResult(IsCorrect);

    public sealed record SingleModel(bool IsCorrect, uint Answer)
        : AnswerResult(IsCorrect);

    public sealed record MultipleModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);

    public sealed record OrderingModel(bool IsCorrect, IEnumerable<uint> Answer)
        : AnswerResult(IsCorrect);
}
