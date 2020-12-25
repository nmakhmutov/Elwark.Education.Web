using Elwark.Education.Web.Infrastructure.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Elwark.Education.Web.Infrastructure
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
                new TestConclusionSummaryJsonConverter(),
                new TestConclusionDetailJsonConverter()
            }
        };
    }
}