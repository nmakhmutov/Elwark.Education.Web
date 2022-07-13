using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Gateways.Converters;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Education.Web.Gateways;

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
            new AchievementModelConverter(),
            new AnswerOptionModelConverter(),
            new AnswerResultModelConverter(),
            new HistoryTopicDetailModelConverter(),
            new InternalMoneyConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            new TestConclusionConverter(),
            new TestOverviewModelConverter(),
            new TestQuestionModelConverter()
        }
    };

    protected static JsonContent CreateJson<T>(T value) =>
        JsonContent.Create(value, null, Serializer);

    protected static async Task<ApiResult<T>> ExecuteAsync<T>(Func<CancellationToken, Task<HttpResponseMessage>> func)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));

        try
        {
            using var message = await func(cts.Token);
            var hasContent = (message.Content.Headers.ContentLength ?? 0) > 0;

            return ((uint)message.StatusCode, hasContent) switch
            {
                (>= 200 and < 300, true) =>
                    ApiResult<T>.Success((await message.Content.ReadFromJsonAsync<T>(Serializer, cts.Token))!),

                (>= 200 and < 300, false) => ApiResult<T>.Success(default!),

                (404, false) => ApiResult<T>.Fail(Error.Create("Resource not found", 404)),
                
                (_, false) => ApiResult<T>.Fail(Error.Create("Unknown server response", 500)),

                _ => ApiResult<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(Serializer, cts.Token))!)
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            return ApiResult<T>.Fail(Error.Create("You are not authorized", 401));
        }
        catch (HttpRequestException)
        {
            return ApiResult<T>.Fail(Error.Create("Server unavailable", 503));
        }
        catch (Exception)
        {
            return ApiResult<T>.Fail(Error.Create("Internal error", 502));
        }
    }
}
