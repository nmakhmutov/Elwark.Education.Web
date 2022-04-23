using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Gateways.Models.Test;

namespace Education.Web.Gateways.Converters;

internal sealed class TestQuestionModelConverter : JsonConverter<TestQuestionModel?>
{
    public override TestQuestionModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<ShortAnswerQuestionModel>(options),
            "single" => document.Deserialize<SingleAnswerQuestionModel>(options),
            "multiple" => document.Deserialize<MultipleAnswerQuestionModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestQuestionModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
