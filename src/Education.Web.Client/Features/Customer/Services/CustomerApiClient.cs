using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Http;
using Education.Web.Client.Http.JsonConverters;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.Customer.Services;

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

    public CustomerApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        IStringLocalizer<App> localizer, AuthenticationStateProvider provider)
        : base(anonymous, authenticated, localizer, provider, Options)
    {
    }
}
