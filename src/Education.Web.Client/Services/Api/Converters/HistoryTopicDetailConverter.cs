using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Services.History.Topic.Model;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class HistoryTopicDetailConverter : JsonConverter<HistoryTopicDetail?>
{
    public override HistoryTopicDetail? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "battle" => document.Deserialize<HistoryTopicDetail.BattleModel>(options),
            "empire" => document.Deserialize<HistoryTopicDetail.EmpireModel>(options),
            "general" => document.Deserialize<HistoryTopicDetail.GeneralModel>(options),
            "person" => document.Deserialize<HistoryTopicDetail.PersonModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown topic detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, HistoryTopicDetail? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
