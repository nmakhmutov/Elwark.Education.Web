using System.Text.Json.Serialization;

namespace Education.Client.Models.Test;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(TextModel), "text"),
 JsonDerivedType(typeof(SingleModel), "single"),
 JsonDerivedType(typeof(MultipleModel), "multiple"),
 JsonDerivedType(typeof(OrderingModel), "ordering")]
public abstract record Question(string Id, string Title, string? ImageUrl)
{
    public sealed record TextModel(string Id, string Title, string? ImageUrl) :
        Question(Id, Title, ImageUrl);

    public sealed record SingleModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);

    public sealed record MultipleModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);

    public sealed record OrderingModel(string Id, string Title, string? ImageUrl, AnswerOption[] Options) :
        Question(Id, Title, ImageUrl);
}
