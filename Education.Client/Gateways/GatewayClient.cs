using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Education.Client.Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json;

namespace Education.Client.Gateways
{
    internal abstract class GatewayClient
    {
        protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

        protected static async Task<ApiResponse<T>> ExecuteAsync<T>(Func<Task<HttpResponseMessage>> handler)
        {
            try
            {
                using var message = await handler();
                await using var stream = await message.Content.ReadAsStreamAsync();
                using var sr = new StreamReader(stream);
                using var jsonTextReader = new JsonTextReader(sr);

                return message.StatusCode switch
                {
                    HttpStatusCode.OK =>
                        ApiResponse<T>.Success(Json.Serializer.Deserialize<T>(jsonTextReader)!),

                    HttpStatusCode.Created =>
                        ApiResponse<T>.Success(Json.Serializer.Deserialize<T>(jsonTextReader)!),

                    HttpStatusCode.Accepted =>
                        ApiResponse<T>.Success(Json.Serializer.Deserialize<T>(jsonTextReader)!),

                    HttpStatusCode.NoContent =>
                        ApiResponse<T>.Success(default!),

                    _ => ApiResponse<T>.Fail(Json.Serializer.Deserialize<Error>(jsonTextReader)!)
                };
            }
            catch (AccessTokenNotAvailableException ex)
            {
                ex.Redirect();
                var error = Error.Create("Unauthorized", "https://tools.ietf.org/html/rfc7235#section-3.1", 401);
                return ApiResponse<T>.Fail(error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var error = Error.Create("Internal", "https://tools.ietf.org/html/rfc7231#section-6.6.3", 502);
                return ApiResponse<T>.Fail(error);
            }
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
