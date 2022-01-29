using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Topic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Converters;

internal sealed class VirtualCurrencyConverter : JsonConverter<IVirtualCurrency?>
{
    private const string Type = "type";

    public override IVirtualCurrency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        return node?[Type]?.GetValue<string>() switch
        {
            "experience" => node.Deserialize<UserExperience>(options),
            "silver" => node.Deserialize<SilverCurrency>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(HistoryTopicDetail), @"Unknown game currency type")
        };
    }

    public override void Write(Utf8JsonWriter writer, IVirtualCurrency? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
