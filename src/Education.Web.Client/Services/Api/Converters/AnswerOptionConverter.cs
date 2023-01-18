using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class AnswerOptionConverter : JsonConverter<AnswerOption?>
{
    public override AnswerOption? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "text" => document.Deserialize<AnswerOption.TextModel>(options),
            "image" => document.Deserialize<AnswerOption.ImageModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AnswerOption), type, @"Unknown answer option")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerOption? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
