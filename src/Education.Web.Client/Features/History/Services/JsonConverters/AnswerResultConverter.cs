using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.JsonConverters;

internal sealed class AnswerResultConverter : JsonConverter<AnswerResult?>
{
    public override AnswerResult? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<AnswerResult.ShortModel>(options),
            "single" => document.Deserialize<AnswerResult.SingleModel>(options),
            "multiple" => document.Deserialize<AnswerResult.MultipleModel>(options),
            "ordered" => document.Deserialize<AnswerResult.OrderedModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AnswerResult), type, @"Unknown answer result")
        };
    }

    public override void Write(Utf8JsonWriter writer, AnswerResult? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
