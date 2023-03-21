using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Web.Client.Http.JsonConverters;

internal sealed class TimeZoneInfoConverter : JsonConverter<TimeZoneInfo>
{
    public override TimeZoneInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tz = reader.GetString();

        if (string.IsNullOrEmpty(tz))
            return TimeZoneInfo.Utc;

        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById(tz);
        }
        catch
        {
            return TimeZoneInfo.Local;
        }
    }

    public override void Write(Utf8JsonWriter writer, TimeZoneInfo value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
