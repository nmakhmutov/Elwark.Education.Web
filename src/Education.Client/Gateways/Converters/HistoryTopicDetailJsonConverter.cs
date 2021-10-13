using System;
using Education.Client.Gateways.History.Topic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryTopicDetailJsonConverter : JsonConverter<TopicDetail?>
{
    private const string Type = "type";

    public override void WriteJson(JsonWriter writer, TopicDetail? value, JsonSerializer serializer) =>
        serializer.Serialize(writer, value);

    public override TopicDetail? ReadJson(JsonReader reader, Type objectType, TopicDetail? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var jObject = JObject.Load(reader);
        if (jObject.Type == JTokenType.Null)
            return null;

        return jObject.Value<string>(Type) switch
        {
            "Person" => jObject.ToObject<PersonTopicDetail>(),
            "Event" => jObject.ToObject<EventTopicDetail>(),
            _ => throw new ArgumentOutOfRangeException(nameof(TopicDetail), @"Unknown topic detail type")
        };
    }
}
