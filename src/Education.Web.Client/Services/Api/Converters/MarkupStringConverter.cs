using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Services.Api.Converters;

internal sealed class MarkupStringConverter : JsonConverter<MarkupString>
{
    public override MarkupString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() is { Length: > 0 } markup ? new MarkupString(markup) : new MarkupString();

    public override void Write(Utf8JsonWriter writer, MarkupString value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
