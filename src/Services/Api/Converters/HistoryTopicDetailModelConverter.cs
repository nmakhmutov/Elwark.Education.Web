using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Services.History.Topic.Model;

namespace Education.Web.Services.Api.Converters;

internal sealed class HistoryTopicDetailModelConverter : JsonConverter<HistoryTopicDetailModel?>
{
    public override HistoryTopicDetailModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "battle" => document.Deserialize<BattleTopicDetailModel>(options),
            "empire" => document.Deserialize<EmpireTopicDetailModel>(options),
            "general" => document.Deserialize<GeneralTopicDetailModel>(options),
            "person" => document.Deserialize<PersonTopicDetailModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, @"Unknown topic detail type")
        };
    }

    public override void Write(Utf8JsonWriter writer, HistoryTopicDetailModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
