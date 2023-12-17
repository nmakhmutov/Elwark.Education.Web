using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Features.History.Clients.User.Model;

namespace Education.Web.Client.Features.History.Clients.JsonConverters;

internal sealed class AchievementConverter : JsonConverter<Achievement?>
{
    public override Achievement? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "completed" => document.Deserialize<Achievement.CompletedModel>(options),
            "ladder" => document.Deserialize<Achievement.LadderModel>(options),
            "progressive" => document.Deserialize<Achievement.ProgressiveModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(Achievement), type, @"Unknown achievement type")
        };
    }

    public override void Write(Utf8JsonWriter writer, Achievement? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
