using Education.Client.Gateways.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Education.Client.Gateways;

internal static class JsonConfiguration
{
    public static readonly JsonSerializer Serializer = new()
    {
        Formatting = Formatting.None,
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters =
        {
            new IsoDateTimeConverter(),
            new StringEnumConverter(new CamelCaseNamingStrategy()),
            new HistoryTopicDetailJsonConverter(),
            new HistoryTestConclusionJsonConverter()
        }
    };
}
