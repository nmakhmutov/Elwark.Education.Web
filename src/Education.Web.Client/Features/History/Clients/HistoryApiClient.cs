using System.Text.Json;
using System.Text.Json.Serialization;
using Education.Web.Client.Clients;
using Education.Web.Client.Clients.JsonConverters;
using Education.Web.Client.Features.History.Clients.JsonConverters;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Clients;

internal sealed class HistoryApiClient : ApiClient
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
            new AchievementConverter(),
            new AnswerOptionConverter(),
            new AnswerResultConverter(),
            new ArticleDetailConverter(),
            new MarkupStringConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
            new QuestionConverter()
        }
    };

    public HistoryApiClient(ApiAnonymousClient anonymous, ApiAuthenticatedClient authenticated,
        IStringLocalizer<App> localizer, AuthenticationStateProvider provider)
        : base(anonymous, authenticated, provider, localizer, Options)
    {
    }
}
