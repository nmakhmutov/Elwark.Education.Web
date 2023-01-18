using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.History.Test.Model;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class TestOverviewConverter : JsonConverter<TestOverview?>
{
    public override TestOverview? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "easy" => document.Deserialize<TestOverview.EasyTestModel>(options),
            "hard" => document.Deserialize<TestOverview.HardTestModel>(options),
            "mixed" => document.Deserialize<TestOverview.MixedTestModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TestConclusion), type, @"Unknown test overview")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestOverview? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
