using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Services.History.User.Model;

namespace Education.Web.Services.Api.Converters;

internal sealed class AchievementModelConverter : JsonConverter<AchievementModel?>
{
    public override AchievementModel? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var type = document.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "completed" => document.Deserialize<CompletedAchievementModel>(options),
            "ladder" => document.Deserialize<LadderAchievementModel>(options),
            "progressive" => document.Deserialize<ProgressiveAchievementModel>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(AchievementModel), type, @"Unknown achievement type")
        };
    }

    public override void Write(Utf8JsonWriter writer, AchievementModel? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
