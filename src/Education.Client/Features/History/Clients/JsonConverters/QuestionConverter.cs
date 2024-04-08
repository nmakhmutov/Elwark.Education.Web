using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.JsonConverters;

internal sealed class QuestionConverter : JsonConverter<Question?>
{
    public override Question? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "text" => document.Deserialize<Question.TextModel>(options),
            "single" => document.Deserialize<Question.SingleModel>(options),
            "multi" => document.Deserialize<Question.MultiModel>(options),
            "ordering" => document.Deserialize<Question.OrderingModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, Question? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
