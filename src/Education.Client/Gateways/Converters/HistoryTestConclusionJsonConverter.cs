using System;
using Education.Client.Gateways.History.Test;
using Education.Client.Gateways.Models.Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Education.Client.Gateways.Converters;

internal sealed class HistoryTestConclusionJsonConverter : JsonConverter<TestConclusion?>
{
    private const string TestType = "testType";

    public override void WriteJson(JsonWriter writer, TestConclusion? value, JsonSerializer serializer) =>
        serializer.Serialize(writer, value);

    public override TestConclusion? ReadJson(JsonReader reader, Type objectType, TestConclusion? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var jObject = JObject.Load(reader);
        if (jObject.Type == JTokenType.Null)
            return null;

        var testType = jObject.Value<string>(TestType);
        if (Enum.TryParse(testType, true, out TestType value))
            return value switch
            {
                Gateways.Models.Test.TestType.Easy => jObject.ToObject<EasyTestConclusion>(),
                Gateways.Models.Test.TestType.Hard => jObject.ToObject<HardTestConclusion>(),
                Gateways.Models.Test.TestType.Mixed => jObject.ToObject<MixedTestConclusion>(),
                _ => throw new ArgumentOutOfRangeException(nameof(reader), value, null)
            };

        throw new JsonReaderException($"Test type '{testType}' cannot be parse");
    }
}
