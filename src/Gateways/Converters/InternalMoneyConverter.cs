using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.Converters;

internal sealed class InternalMoneyConverter : JsonConverter<IInternalMoney?>
{
    public override IInternalMoney? Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var name = document.RootElement.GetProperty("name").GetString();

        return name switch
        {
            "Experience" => document.Deserialize<Experience>(options),
            "Silver" => document.Deserialize<Silver>(options),
            _ => throw new ArgumentOutOfRangeException(nameof(IInternalMoney), name, @"Unknown internal money")
        };
    }

    public override void Write(Utf8JsonWriter writer, IInternalMoney? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}
