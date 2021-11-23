using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Education.Client.Gateways.Converters;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Education.Client.Gateways;

internal abstract class GatewayClient
{
    private static readonly JsonSerializerOptions Serializer = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        IgnoreReadOnlyProperties = false,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            new GameCurrencyConverter(),
            new HistoryTestConclusionJsonConverter(),
            new HistoryTopicDetailJsonConverter(),
            new HistoryAchievementConverter()
        }
    };

    protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

    protected static JsonContent CreateJson<T>(T value) =>
        JsonContent.Create(value, null, Serializer);
    
    protected static async Task<ApiResponse<T>> ExecuteAsync<T>(Func<CancellationToken, Task<HttpResponseMessage>> action)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        try
        {
            using var message = await action(cts.Token);
            
            return message.IsSuccessStatusCode
                ? message.StatusCode == HttpStatusCode.NoContent
                    ? ApiResponse<T>.Success(default!)
                    : ApiResponse<T>.Success((await message.Content.ReadFromJsonAsync<T>(Serializer, cts.Token))!)
                : ApiResponse<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(Serializer, cts.Token))!);
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
}
