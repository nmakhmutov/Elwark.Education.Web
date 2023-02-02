using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Http;

internal abstract class ApiClient
{
    private readonly ApiAnonymousClient _anonymous;
    private readonly ApiAuthenticatedClient _authenticated;
    private readonly IStringLocalizer<App> _localizer;
    private readonly JsonSerializerOptions _options;
    private readonly AuthenticationStateProvider _provider;

    protected ApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        IStringLocalizer<App> localizer, AuthenticationStateProvider provider, JsonSerializerOptions options)
    {
        _anonymous = anonymous;
        _authenticated = authenticated;
        _localizer = localizer;
        _provider = provider;
        _options = options;
    }

    public async Task<ApiResult<T>> GetAsync<T>(string uri, IQueryStringRequest? request = null)
    {
        var url = GetRequestUrl(uri, request);
        var state = await _provider.GetAuthenticationStateAsync();

        if (state.User.Identity?.IsAuthenticated == false)
            return await ExecuteAsync<T>(ct => _anonymous.GetAsync(url, ct));

        return await ExecuteAsync<T>(ct => _authenticated.GetAsync(url, ct));
    }

    public Task<ApiResult<T>> PostAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.PostAsync(uri, null, ct));

    public Task<ApiResult<T>> PostAsync<T, K>(string uri, K data) =>
        ExecuteAsync<T>(ct => _authenticated.PostAsync(uri, CreateJson(data), ct));

    public Task<ApiResult<T>> PutAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.PutAsync(uri, null, ct));

    public Task<ApiResult<T>> PutAsync<T, K>(string uri, K data) =>
        ExecuteAsync<T>(ct => _authenticated.PutAsync(uri, CreateJson(data), ct));

    public Task<ApiResult<T>> DeleteAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.DeleteAsync(uri, ct));

    private static string GetRequestUrl(string uri, IQueryStringRequest? request)
    {
        if (request is null)
            return uri;

        var query = request.ToQueryString();
        return query.HasValue ? $"{uri}{query}" : uri;
    }

    private JsonContent CreateJson<T>(T value) =>
        JsonContent.Create(value, null, _options);

    private async Task<ApiResult<T>> ExecuteAsync<T>(Func<CancellationToken, Task<HttpResponseMessage>> func)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        try
        {
            using var message = await func(cts.Token);
            var hasContent = (message.Content.Headers.ContentLength ?? 0) > 0;

            return ((uint)message.StatusCode, hasContent) switch
            {
                (>= 200 and < 300, true) =>
                    ApiResult<T>.Success((await message.Content.ReadFromJsonAsync<T>(_options, cts.Token))!),

                (>= 200 and < 300, false) => ApiResult<T>.Success(default!),

                (403, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error:AccessDenied"], 403)),

                (404, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error:NotFound"], 404)),

                (_, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error:InternalServerError"], 500)),

                _ => ApiResult<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(_options, cts.Token))!)
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            return ApiResult<T>.Fail(Error.Create(_localizer["Error:AccessDenied"], 403));
        }
        catch (HttpRequestException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error:ServiceUnavailable"], 503));
        }
        catch (TaskCanceledException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error:RequestTimeout"], 408));
        }
        catch (Exception ex)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error:BadGateway"], 502, ex.Message));
        }
    }
}
