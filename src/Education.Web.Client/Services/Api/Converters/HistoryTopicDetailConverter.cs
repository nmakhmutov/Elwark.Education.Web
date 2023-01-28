using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.History.Topic.Model;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class HistoryTopicDetailConverter : JsonConverter<TopicDetail?>
{
    public override TopicDetail? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "battle" => document.Deserialize<TopicDetail.BattleModel>(options),
            "empire" => document.Deserialize<TopicDetail.EmpireModel>(options),
            "general" => document.Deserialize<TopicDetail.GeneralModel>(options),
            "person" => document.Deserialize<TopicDetail.PersonModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown topic detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, TopicDetail? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
