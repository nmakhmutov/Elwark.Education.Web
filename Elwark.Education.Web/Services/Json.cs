using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elwark.Education.Web.Services
{
    public static class Json
    {
        public static JsonSerializerOptions Options => new()
        {
            Converters = {new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)},
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}