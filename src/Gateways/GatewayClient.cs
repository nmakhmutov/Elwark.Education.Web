using System.Net.Http.Json;
using System.Text;
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
            new DateOnlyConverter(),
            new HistoryTopicDetailModelConverter(),
            new InternalMoneyConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            new TestConclusionConverter(),
            new TestOverviewModelConverter(),
            new TestQuestionModelConverter(),
            new TimeOnlyConverter()
        }
    };

    protected static readonly StringContent EmptyContent = new(string.Empty, Encoding.UTF8, "application/json");

    protected static JsonContent CreateJson<T>(T value) =>
        JsonContent.Create(value, null, Serializer);

    protected static async Task<ApiResponse<T>> ExecuteAsync<T>(Func<CancellationToken, Task<HttpResponseMessage>> func)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        try
        {
            using var message = await func(cts.Token);

            return (uint)message.StatusCode switch
            {
                204 => ApiResponse<T>.Success(default!),

                > 199 and < 300 =>
                    ApiResponse<T>.Success((await message.Content.ReadFromJsonAsync<T>(Serializer, cts.Token))!),

                _ => ApiResponse<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(Serializer, cts.Token))!)
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            return ApiResponse<T>.Fail(Error.Create("You are not authorized", 401));
        }
        catch (HttpRequestException)
        {
            return ApiResponse<T>.Fail(Error.Create("Server unavailable", 503));
        }
        catch (Exception)
        {
            return ApiResponse<T>.Fail(Error.Create("Internal error", 502));
        }
    }
}
