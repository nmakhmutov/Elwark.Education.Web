using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Test;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryTestConclusionJsonConverter : JsonConverter<TestConclusion?>
{
    private const string Type = "testType";

    public override TestConclusion? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        if (Enum.TryParse<TestType>(node?[Type]?.GetValue<string>(), true, out var type))
            return type switch
            {
                TestType.Easy => node.Deserialize<EasyTestConclusion>(options),
                TestType.Hard => node.Deserialize<HardTestConclusion>(options),
                TestType.Mixed => node.Deserialize<MixedTestConclusion>(options),
                _ => throw new ArgumentOutOfRangeException(nameof(TestConclusion), @"Unknown topic conclusion type")
            };

        return null;
    }

    public override void Write(Utf8JsonWriter writer, TestConclusion? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
