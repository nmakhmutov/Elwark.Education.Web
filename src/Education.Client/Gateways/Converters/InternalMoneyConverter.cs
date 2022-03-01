using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Converters;

internal sealed class InternalMoneyConverter : JsonConverter<IInternalMoney?>
{
    public override IInternalMoney? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var name = document.RootElement.GetProperty("name").GetString();

        return name switch
        {
            "experience" => document.Deserialize<Experience>(options),
            "silver" => document.Deserialize<Silver>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(IInternalMoney), name, @"Unknown internal currency")
        };
    }

    public override void Write(Utf8JsonWriter writer, IInternalMoney? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
