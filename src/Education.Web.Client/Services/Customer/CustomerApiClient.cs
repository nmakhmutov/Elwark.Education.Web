using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Http;
using Education.Web.Client.Services.Api.Converters;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Client.Services.Customer;

internal sealed class CustomerApiClient : ApiClient
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        IgnoreReadOnlyProperties = false,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Converters =
        {
            new MarkupStringConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };

    private readonly ApiAnonymousClient _anonymous;
    private readonly ApiAuthenticatedClient _authenticated;
    private readonly AuthenticationStateProvider _provider;

    public CustomerApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        AuthenticationStateProvider provider)
    {
        _anonymous = anonymous;
        _authenticated = authenticated;
        _provider = provider;
    }

    public async Task<ApiResult<T>> GetAsync<T>(string uri, IQueryStringRequest? request = null)
    {
        var url = GetRequestUrl(uri, request);
        var state = await _provider.GetAuthenticationStateAsync();

        if (state.User.Identity?.IsAuthenticated == false)
            return await ExecuteAsync<T>(ct => _anonymous.GetAsync(url, ct), Options);

        return await ExecuteAsync<T>(ct => _authenticated.GetAsync(url, ct), Options);
    }

    public Task<ApiResult<T>> PostAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.PostAsync(uri, null, ct), Options);

    public Task<ApiResult<T>> PostAsync<T, K>(string uri, K data) =>
        ExecuteAsync<T>(ct => _authenticated.PostAsync(uri, CreateJson(data, Options), ct), Options);

    public Task<ApiResult<T>> PutAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.PutAsync(uri, null, ct), Options);

    public Task<ApiResult<T>> PutAsync<T, K>(string uri, K data) =>
        ExecuteAsync<T>(ct => _authenticated.PutAsync(uri, CreateJson(data, Options), ct), Options);

    public Task<ApiResult<T>> DeleteAsync<T>(string uri) =>
        ExecuteAsync<T>(ct => _authenticated.DeleteAsync(uri, ct), Options);
}
