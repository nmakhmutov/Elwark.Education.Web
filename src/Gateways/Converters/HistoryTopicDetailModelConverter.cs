using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Gateways.History.Topics.Model;

namespace Education.Web.Gateways.Converters;

internal sealed class HistoryTopicDetailModelConverter : JsonConverter<HistoryTopicDetailModel?>
{
    public override HistoryTopicDetailModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "person" => document.Deserialize<PersonTopicDetailModel>(options),
            "event" => document.Deserialize<EventTopicDetailModel>(options),
            "empire" => document.Deserialize<EmpireTopicDetailModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown topic detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, HistoryTopicDetailModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
