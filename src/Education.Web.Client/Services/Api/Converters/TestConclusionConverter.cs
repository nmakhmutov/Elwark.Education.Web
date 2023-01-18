using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.History.Test.Model;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class TestConclusionConverter : JsonConverter<TestConclusion?>
{
    public override TestConclusion? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "easy" => document.Deserialize<TestConclusion.EasyTestModel>(options),
            "hard" => document.Deserialize<TestConclusion.HardTestModel>(options),
            "mixed" => document.Deserialize<TestConclusion.MixedTestModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown test conclusion")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestConclusion? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
