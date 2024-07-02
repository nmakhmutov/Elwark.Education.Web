using Education.Client.Clients;
using Education.Client.Clients.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace Education.Client.Extensions;

internal static class HostExtensions
{
    public static WebAssemblyHostBuilder AddInfrastructure(this WebAssemblyHostBuilder builder)
    {
        var gatewayUrl = builder.Configuration.GetValue<Uri>("Urls:Gateway")!;

        builder.Services
            .AddScoped<LocalizationHandler>()
            .AddScoped<AuthorizationMessageHandler>(provider =>
            {
                var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
                var navigation = provider.GetRequiredService<NavigationManager>();

                return new AuthorizationMessageHandler(tokenProvider, navigation)
                    .ConfigureHandler([gatewayUrl.ToString()]);
            });

        var anonymous = builder.Services
            .AddHttpClient<ApiAnonymousClient>(client => client.BaseAddress = gatewayUrl)
            .AddHttpMessageHandler<LocalizationHandler>();

        var authenticated = builder.Services
            .AddHttpClient<ApiAuthenticatedClient>(client => client.BaseAddress = gatewayUrl)
            .AddHttpMessageHandler<LocalizationHandler>()
            .AddHttpMessageHandler<AuthorizationMessageHandler>();

        if (builder.HostEnvironment.IsProduction())
        {
            anonymous.AddStandardResilienceHandler(ResilienceOptions);
            authenticated.AddStandardResilienceHandler(ResilienceOptions);
        }

        return builder;

        void ResilienceOptions(HttpStandardResilienceOptions options)
        {
            options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
            options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
            options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(2);
            options.Retry.UseJitter = true;
            options.Retry.ShouldRetryAfterHeader = true;
            options.Retry.BackoffType = DelayBackoffType.Exponential;
        }
    }
}
