using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class TestQuestionConverter : JsonConverter<TestQuestion?>
{
    public override TestQuestion? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<TestQuestion.ShortModel>(options),
            "single" => document.Deserialize<TestQuestion.SingleModel>(options),
            "multiple" => document.Deserialize<TestQuestion.MultipleModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestQuestion? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
