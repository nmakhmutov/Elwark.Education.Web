using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            return message.IsSuccessStatusCode
                ? message.StatusCode == HttpStatusCode.NoContent
                    ? ApiResponse<T>.Success(default!)
                    : ApiResponse<T>.Success((await message.Content.ReadFromJsonAsync<T>(Serializer, cts.Token))!)
                : ApiResponse<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(Serializer, cts.Token))!);
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            var error = Error.Create("Unauthorized", 401);
            return ApiResponse<T>.Fail(error);
        }
        catch (HttpRequestException)
        {
            var error = Error.Create("Unavailable", 503);
            return ApiResponse<T>.Fail(error);
        }
        catch (Exception ex)
        {
            var error = Error.Create("Internal", 502, ex.Message);
            return ApiResponse<T>.Fail(error);
        }
    }
}
