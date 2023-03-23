using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.JsonConverters;

internal sealed class TestQuestionConverter : JsonConverter<QuizQuestion?>
{
    public override QuizQuestion? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<QuizQuestion.ShortModel>(options),
            "single" => document.Deserialize<QuizQuestion.SingleModel>(options),
            "multiple" => document.Deserialize<QuizQuestion.MultipleModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, QuizQuestion? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
