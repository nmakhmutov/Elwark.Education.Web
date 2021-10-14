using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json;

namespace Education.Client.Gateways;

internal abstract class GatewayClient
{
    protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

    protected static async Task<ApiResponse<T>> ExecuteAsync<T>(Func<CancellationToken, Task<HttpResponseMessage>> action)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        
        try
        {
            using var message = await action(cts.Token);
            await using var stream = await message.Content.ReadAsStreamAsync(cts.Token);
            using var sr = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(sr);

            return message.StatusCode switch
            {
                HttpStatusCode.OK =>
                    ApiResponse<T>.Success(JsonConfiguration.Serializer.Deserialize<T>(jsonTextReader)!),

                HttpStatusCode.Created =>
                    ApiResponse<T>.Success(JsonConfiguration.Serializer.Deserialize<T>(jsonTextReader)!),

                HttpStatusCode.Accepted =>
                    ApiResponse<T>.Success(JsonConfiguration.Serializer.Deserialize<T>(jsonTextReader)!),

                HttpStatusCode.NoContent =>
                    ApiResponse<T>.Success(default!),

                _ => ApiResponse<T>.Fail(JsonConfiguration.Serializer.Deserialize<Error>(jsonTextReader)!)
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            var error = Error.Create("Unauthorized", "https://tools.ietf.org/html/rfc7235#section-3.1", 401);
            return ApiResponse<T>.Fail(error);
        }
        catch (HttpRequestException)
        {
            var error = Error.Create("Unavailable", "https://tools.ietf.org/html/rfc7231#section-6.6.4", 503);
            return ApiResponse<T>.Fail(error);
        }
        catch (Exception)
        {
            var error = Error.Create("Internal", "https://tools.ietf.org/html/rfc7231#section-6.6.3", 502);
            return ApiResponse<T>.Fail(error);
        }
    }

    protected static StringContent ToJson<T>(T value)
    {
        var sb = new StringBuilder(256);
        var sw = new StringWriter(sb, CultureInfo.InvariantCulture);
        using var jsonWriter = new JsonTextWriter(sw) { Formatting = JsonConfiguration.Serializer.Formatting };

        JsonConfiguration.Serializer.Serialize(jsonWriter, value);

        return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
    }
}
