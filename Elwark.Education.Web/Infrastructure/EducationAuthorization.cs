using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Options;

namespace Elwark.Education.Web.Infrastructure
{
    public class EducationAuthorization : AuthorizationMessageHandler
    {
        public EducationAuthorization(IAccessTokenProvider provider, NavigationManager navigation, UrlsOptions urls,
            IOptions<RemoteAuthenticationOptions<OidcProviderOptions>> oidc)
            : base(provider, navigation) =>
            ConfigureHandler(new[] {urls.Gateway.ToString()}, oidc.Value.ProviderOptions.DefaultScopes);
    }
}