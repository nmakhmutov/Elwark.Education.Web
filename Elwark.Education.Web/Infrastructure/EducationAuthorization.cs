using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Elwark.Education.Web.Infrastructure
{
    public class EducationAuthorization : AuthorizationMessageHandler
    {
        public EducationAuthorization(IAccessTokenProvider provider, NavigationManager navigation, UrlsOptions urls)
            : base(provider, navigation) => ConfigureHandler(new[] {urls.Gateway.ToString()});
    }
}
