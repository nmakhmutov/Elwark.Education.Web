using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Education.Client.Gateways.History.Topic;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryTopicDetailJsonConverter : JsonConverter<TopicDetail?>
{
    private const string Type = "type";

    public override TopicDetail? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var node = JsonNode.Parse(ref reader);

        return node?[Type]?.GetValue<string>() switch
        {
            "Person" => node.Deserialize<PersonTopicDetail>(options),
            "Event" => node.Deserialize<EventTopicDetail>(options),
            "Empire" => node.Deserialize<EmpireTopicDetail>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(TopicDetail), @"Unknown topic detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, TopicDetail? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
