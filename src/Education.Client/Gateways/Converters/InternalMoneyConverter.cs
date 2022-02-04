using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Topic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Converters;

internal sealed class InternalMoneyConverter : JsonConverter<IInternalMoney?>
{
    public override IInternalMoney? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        return node?["name"]?.GetValue<string>() switch
        {
            nameof(Experience) => node.Deserialize<Experience>(options),
            nameof(Silver) => node.Deserialize<Silver>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(HistoryTopicDetail), @"Unknown game currency type")
        };
    }

    public override void Write(Utf8JsonWriter writer, IInternalMoney? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
