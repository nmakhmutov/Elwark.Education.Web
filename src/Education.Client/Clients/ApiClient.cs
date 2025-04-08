using System.Net.Http.Json;
using System.Text.Json;
using Education.Client.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Localization;

namespace Education.Client.Clients;

internal abstract class ApiClient
{
    private static readonly Type InputType = typeof(object);
    private readonly ApiAnonymousClient _anonymous;
    private readonly ApiAuthenticatedClient _authenticated;
    private readonly IStringLocalizer _localizer;
    private readonly JsonSerializerOptions _options;
    private readonly AuthenticationStateProvider _provider;

    protected ApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        AuthenticationStateProvider provider, IStringLocalizer localizer, JsonSerializerOptions options)
    {
        _anonymous = anonymous;
        _authenticated = authenticated;
        _localizer = localizer;
        _provider = provider;
        _options = options;
    }

    public async Task<ApiResult<T>> GetAsync<T>(string url, CancellationToken ct = default)
    {
        var state = await _provider.GetAuthenticationStateAsync();

        if (state.User.IsAuthenticated())
            return await ExecuteAsync<T>(token => _authenticated.GetAsync(url, token), ct);

        return await ExecuteAsync<T>(token => _anonymous.GetAsync(url, token), ct);
    }

    public Task<ApiResult<T>> GetAsync<T>(string url, IQueryStringRequest request, CancellationToken ct = default)
    {
        if (request.ToQueryString() is { HasValue: true } query)
            return GetAsync<T>($"{url}{query}", ct);

        return GetAsync<T>(url, ct);
    }

    public async Task<ApiResult<T>> PostAsync<T>(string url, CancellationToken ct = default)
    {
        var state = await _provider.GetAuthenticationStateAsync();

        if (state.User.IsAuthenticated())
            return await ExecuteAsync<T>(token => _authenticated.PostAsync(url, null, token), ct);

        return await ExecuteAsync<T>(token => _anonymous.PostAsync(url, null, token), ct);
    }

    public async Task<ApiResult<T>> PostAsync<T, U>(string url, U data, CancellationToken ct = default)
    {
        var state = await _provider.GetAuthenticationStateAsync();
        var content = CreateJson(data);

        if (state.User.IsAuthenticated())
            return await ExecuteAsync<T>(token => _authenticated.PostAsync(url, content, token), ct);

        return await ExecuteAsync<T>(token => _anonymous.PostAsync(url, content, token), ct);
    }

    public Task<ApiResult<T>> PutAsync<T>(string url, CancellationToken ct = default) =>
        ExecuteAsync<T>(token => _authenticated.PutAsync(url, null, token), ct);

    public Task<ApiResult<T>> PutAsync<T, U>(string url, U data, CancellationToken ct = default) =>
        ExecuteAsync<T>(token => _authenticated.PutAsync(url, CreateJson(data), token), ct);

    public Task<ApiResult<T>> DeleteAsync<T>(string url, CancellationToken ct = default) =>
        ExecuteAsync<T>(token => _authenticated.DeleteAsync(url, token), ct);

    private JsonContent CreateJson<T>(T value) =>
        JsonContent.Create(value, InputType, null, _options);

    private async Task<ApiResult<T>> ExecuteAsync<T>(
        Func<CancellationToken, Task<HttpResponseMessage>> action,
        CancellationToken ct
    )
    {
        try
        {
            using var message = await action(ct)
                .ConfigureAwait(false);

            var status = (uint)message.StatusCode;
            var hasContent = (message.Content.Headers.ContentLength ?? 0) > 0;

            return (status, hasContent) switch
            {
                (>= 200 and < 300, true) =>
                    ApiResult<T>.Success((await message.Content.ReadFromJsonAsync<T>(_options, ct))!),

                (>= 200 and < 300, false) => ApiResult<T>.Success(default!),

                (401, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error_Unauthorized"], 401)),

                (403, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error_AccessDenied"], 403)),

                (404, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error_NotFound"])),

                (_, false) => ApiResult<T>.Fail(Error.Create(_localizer["Error_InternalServerError"], 500)),

                _ => ApiResult<T>.Fail((await message.Content.ReadFromJsonAsync<Error>(_options, ct))!)
            };
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
            return ApiResult<T>.Fail(Error.Create(_localizer["Error_AccessDenied"], 403));
        }
        catch (HttpRequestException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error_ServiceUnavailable"], 503));
        }
        catch (TaskCanceledException)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error_RequestTimeout"], 408));
        }
        catch (Exception ex)
        {
            return ApiResult<T>.Fail(Error.Create(_localizer["Error_BadGateway"], 502, ex.Message));
        }
    }
}
