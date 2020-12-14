using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Elwark.Education.Web.Services;
using Newtonsoft.Json;

namespace Elwark.Education.Web.Infrastructure
{
    internal abstract class GatewayClient
    {
        protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

        protected static async Task<ApiResponse<T>> ToApiResponse<T>(HttpResponseMessage message)
        {
            await using var stream = await message.Content.ReadAsStreamAsync();
            using var sr = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(sr);
            if (message.IsSuccessStatusCode)
                return ApiResponse<T>.Success(Json.Serializer.Deserialize<T>(jsonTextReader)!);

            var error = Json.Serializer.Deserialize<Error>(jsonTextReader)
                        ?? new Error("Unknown", "Unknown", string.Empty);

            return ApiResponse<T>.Fail(error);
        }

        protected static StringContent ToJson<T>(T value)
        {
            var sb = new StringBuilder(256);
            var sw = new StringWriter(sb, CultureInfo.InvariantCulture);
            using var jsonWriter = new JsonTextWriter(sw) {Formatting = Json.Serializer.Formatting};

            Json.Serializer.Serialize(jsonWriter, value);

            return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
        }
    }
}