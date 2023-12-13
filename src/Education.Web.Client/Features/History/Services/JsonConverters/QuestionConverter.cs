using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.JsonConverters;

internal sealed class QuestionConverter : JsonConverter<Question?>
{
    public override Question? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<Question.ShortModel>(options),
            "single" => document.Deserialize<Question.SingleModel>(options),
            "multiple" => document.Deserialize<Question.MultipleModel>(options),
            "ordered" => document.Deserialize<Question.OrderedModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, Question? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
