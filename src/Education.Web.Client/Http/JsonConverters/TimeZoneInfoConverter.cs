using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Web.Client.Http.JsonConverters;

internal sealed class TimeZoneInfoConverter : JsonConverter<TimeZoneInfo>
{
    public override TimeZoneInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() is { Length: > 0 } zone ? TimeZoneInfo.FindSystemTimeZoneById(zone) : TimeZoneInfo.Utc;

    public override void Write(Utf8JsonWriter writer, TimeZoneInfo value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
