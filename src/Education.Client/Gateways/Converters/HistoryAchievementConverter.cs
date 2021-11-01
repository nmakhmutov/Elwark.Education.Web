using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Me;
using Education.Client.Gateways.History.Topic;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryAchievementConverter : JsonConverter<Achievement?>
{
    private const string Type = "type";

    public override Achievement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);
        
        return node?[Type]?.GetValue<string>() switch
        {
            "common" => node.Deserialize<CommonAchievement>(options),
            "leveled" => node.Deserialize<LeveledAchievement>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TopicDetail), @"Unknown achievement type")
        };
    }

    public override void Write(Utf8JsonWriter writer, Achievement? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
