using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Topic;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Converters;

internal sealed class GameCurrencyConverter : JsonConverter<IGameCurrency?>
{
    private const string Type = "type";

    public override IGameCurrency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        return node?[Type]?.GetValue<string>() switch
        {
            "experience" => node.Deserialize<ExperienceCurrency>(options),
            "silver" => node.Deserialize<SilverCurrency>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TopicDetail), @"Unknown game currency type")
        };
    }

    public override void Write(Utf8JsonWriter writer, IGameCurrency? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
