using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Tests.Model;

namespace Education.Client.Gateways.Converters;

internal sealed class TestConclusionConverter : JsonConverter<TestConclusionModel?>
{
    public override TestConclusionModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "easy" => document.Deserialize<EasyTestConclusionModel>(options),
            "hard" => document.Deserialize<HardTestConclusionModel>(options),
            "mixed" => document.Deserialize<MixedTestConclusionModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TestConclusionModel), type, @"Unknown topic conclusion type")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestConclusionModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
