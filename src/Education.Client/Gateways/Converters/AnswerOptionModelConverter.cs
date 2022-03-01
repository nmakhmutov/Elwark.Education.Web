using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Converters;

internal sealed class AnswerOptionModelConverter : JsonConverter<AnswerOptionModel?>
{
    public override AnswerOptionModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "text" => document.Deserialize<TextAnswerOptionModel>(options),
            "image" => document.Deserialize<ImageAnswerOptionModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AnswerOptionModel), type, @"Unknown answer option")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerOptionModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
