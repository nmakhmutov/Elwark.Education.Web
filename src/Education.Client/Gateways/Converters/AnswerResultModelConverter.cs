using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Converters;

internal sealed class AnswerResultModelConverter : JsonConverter<AnswerResultModel?>
{
    public override AnswerResultModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<ShortAnswerResultModel>(options),
            "single" => document.Deserialize<SingleAnswerResultModel>(options),
            "multiple" => document.Deserialize<MultipleAnswersResultModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AnswerResultModel), type, @"Unknown answer result")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerResultModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
