using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Elwark.Education.Web.Infrastructure
{
    public class EducationAuthorization : AuthorizationMessageHandler
    {
        public EducationAuthorization(IAccessTokenProvider provider, NavigationManager navigation, UrlsOptions options) 
            : base(provider, navigation) =>
            ConfigureHandler(
                new[] {options.Gateway.ToString()},
                new[] {"elwark.education.web"}
            );
    }
}