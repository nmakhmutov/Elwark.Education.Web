using System.Net.Http.Json;
using System.Text.Json;
using Education.Http.Resources;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Education.Http;

public abstract class ApiClient
{
    private readonly ILanguageManager _localizer;

    protected ApiClient() =>
        _localizer = new LanguageManager();

    protected static string GetRequestUrl(string uri, IQueryStringRequest? request)
    {
        if (request is null)
            return uri;

        var query = request.ToQueryString();
        return query.HasValue ? $"{uri}{query}" : uri;
    }

    protected static JsonContent CreateJson<T>(T value, JsonSerializerOptions options) =>
        JsonContent.Create(value, null, options);

    protected async Task<ApiResult<T>> ExecuteAsync<T>(
        Func<CancellationToken, Task<HttpResponseMessage>> func,
        JsonSerializerOptions options
    )
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        try
        {
            using var message = await func(cts.Token).ConfigureAwait(false);
            var hasContent = (message.Content.Headers.ContentLength ?? 0) > 0;

            return ((uint)message.StatusCode, hasContent) switch
            {
                (>= 200 and < 300, true) => await message.AsSuccess<T>(options, cts.Token),
                (>= 200 and < 300, false) => ApiResult<T>.Success(default!),
                (403, false) => ApiResult<T>.Fail(Error.Create(_localizer.GetString("AccessDeniedMessage"), 403)),
                (404, false) => ApiResult<T>.Fail(Error.Create(_localizer.GetString("NotFound"), 404)),
                (_, true) => await message.AsFailed<T>(options, cts.Token),
                (_, false) => ApiResult<T>.Fail(Error.Create(_localizer.GetString("InternalServerError"), 500))
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            return ApiResult<T>.Fail(Error.Create(_localizer.GetString("AccessDenied"), 403));
        }
        catch (HttpRequestException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer.GetString("ServiceUnavailable"), 503));
        }
        catch (TaskCanceledException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer.GetString("RequestTimeout"), 408));
        }
        catch (Exception ex)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer.GetString("BadGateway"), 502, ex.Message));
        }
    }
}

internal static class Extensions
{
    public static async Task<ApiResult<T>> AsSuccess<T>(this HttpResponseMessage message, JsonSerializerOptions options,
        CancellationToken ct)
    {
        var json = await message.Content.ReadFromJsonAsync<T>(options, ct);
        return ApiResult<T>.Success(json ?? throw new JsonException("Response json cannot be null"));
    }

    public static async Task<ApiResult<T>> AsFailed<T>(this HttpResponseMessage message, JsonSerializerOptions options,
        CancellationToken ct)
    {
        var json = await message.Content.ReadFromJsonAsync<Error>(options, ct);
        return ApiResult<T>.Fail(json ?? throw new JsonException("Response json cannot be null"));
    }
}
