using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.JsonConverters;

internal sealed class AnswerResultConverter : JsonConverter<AnswerResult?>
{
    public override AnswerResult? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "text" => document.Deserialize<AnswerResult.TextModel>(options),
            "single" => document.Deserialize<AnswerResult.SingleModel>(options),
            "multi" => document.Deserialize<AnswerResult.MultiModel>(options),
            "ordering" => document.Deserialize<AnswerResult.OrderingModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AnswerResult), type, @"Unknown answer result")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerResult? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
