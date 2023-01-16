using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class TestQuestionModelConverter : JsonConverter<TestQuestionModel?>
{
    public override TestQuestionModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "short" => document.Deserialize<TestQuestionModel.ShortAnswerQuestionModel>(options),
            "single" => document.Deserialize<TestQuestionModel.SingleAnswerQuestionModel>(options),
            "multiple" => document.Deserialize<TestQuestionModel.MultipleAnswerQuestionModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test question")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestQuestionModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
