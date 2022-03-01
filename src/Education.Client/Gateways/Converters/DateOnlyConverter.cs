using System.Text.Json;
using System.Text.Json.Serialization;

namespace Education.Client.Gateways.Converters;

internal sealed class DateOnlyConverter : JsonConverter<DateOnly>
{
    private const string SerializationFormat = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options) =>
        DateOnly.Parse(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(SerializationFormat));
}
