using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Elwark.Education.Web.Services
{
    public class AuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly NavigationManager _navigation;

        public AuthorizationDelegatingHandler(IAccessTokenProvider tokenProvider, NavigationManager navigation)
        {
            _tokenProvider = tokenProvider;
            _navigation = navigation;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var tokenResult = await _tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Value);
            else
                throw new AccessTokenNotAvailableException(_navigation, tokenResult, Array.Empty<string>());

            return await base.SendAsync(request, ct);
        }
    }
}