using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Services.Model.Test;

namespace Education.Web.Services.Api.Converters;

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
