using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Topic;
using Education.Client.Gateways.History.User;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryAchievementConverter : JsonConverter<Achievement?>
{
    private const string Type = "type";

    public override Achievement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        return node?[Type]?.GetValue<string>() switch
        {
            "completed" => node.Deserialize<CompletedAchievement>(options),
            "ladder" => node.Deserialize<LadderAchievement>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(HistoryTopicDetail), @"Unknown achievement type")
        };
    }

    public override void Write(Utf8JsonWriter writer, Achievement? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
