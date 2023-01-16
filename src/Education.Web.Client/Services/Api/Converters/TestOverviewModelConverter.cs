using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.History.Test.Model;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class TestOverviewModelConverter : JsonConverter<TestOverviewModel?>
{
    public override TestOverviewModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "easy" => document.Deserialize<TestOverviewModel.EasyTestOverviewModel>(options),
            "hard" => document.Deserialize<TestOverviewModel.HardTestOverviewModel>(options),
            "mixed" => document.Deserialize<TestOverviewModel.MixedTestOverviewModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TestConclusionModel), type, @"Unknown test overview")
        };
    }

    public override void Write(Utf8JsonWriter writer, TestOverviewModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
