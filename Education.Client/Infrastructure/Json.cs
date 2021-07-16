using Education.Client.Infrastructure.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Education.Client.Infrastructure
{
    internal static class Json
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
}
