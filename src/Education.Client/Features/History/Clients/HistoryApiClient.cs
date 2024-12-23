using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Client.Clients;
using Education.Client.Clients.JsonConverters;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Clients;

internal sealed class HistoryApiClient : ApiClient
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        IgnoreReadOnlyProperties = false,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        Converters =
        {
            new MarkupStringConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
        }
    };

    public HistoryApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        IStringLocalizer<App> localizer, AuthenticationStateProvider provider)
        : base(anonymous, authenticated, provider, localizer, Options)
    {
    }
}
