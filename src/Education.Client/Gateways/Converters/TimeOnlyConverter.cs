using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Client.Gateways.Converters;

internal sealed class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private const string SerializationFormat = "HH:mm:ss.fff";

    public override TimeOnly Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options) =>
        TimeOnly.Parse( reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(SerializationFormat));
}
