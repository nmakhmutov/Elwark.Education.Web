using System.Text.Json.Serialization;

namespace Education.Client.Models.Test;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(TextModel), "text"),
 JsonDerivedType(typeof(ImageModel), "image")]
public abstract record AnswerOption(uint Id)
{
    public sealed record TextModel(uint Id, string Text)
        : AnswerOption(Id);

    public sealed record ImageModel(uint Id, string ImageUrl)
        : AnswerOption(Id);
}
