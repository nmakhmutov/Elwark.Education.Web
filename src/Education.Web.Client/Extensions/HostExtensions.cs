using Education.Web.Client.Clients;
using Education.Web.Client.Clients.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Education.Web.Client.Extensions;

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
                    .ConfigureHandler(new[] { gatewayUrl.ToString() });
            });

        builder.Services
            .AddHttpClient<ApiAnonymousClient>(client => client.BaseAddress = gatewayUrl)
            .AddHttpMessageHandler<LocalizationHandler>()
            .AddStandardResilienceHandler(options =>
            {
                options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
                options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
                options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(2);
                options.Retry.UseJitter = true;
                options.Retry.MaxRetryAttempts = builder.HostEnvironment.IsDevelopment() ? 1 : 5;
            });

        builder.Services
            .AddHttpClient<ApiAuthenticatedClient>(client => client.BaseAddress = gatewayUrl)
            .AddHttpMessageHandler<LocalizationHandler>()
            .AddHttpMessageHandler<AuthorizationMessageHandler>()
            .AddStandardResilienceHandler(options =>
            {
                options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
                options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
                options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(2);
                options.Retry.UseJitter = true;
                options.Retry.MaxRetryAttempts = builder.HostEnvironment.IsDevelopment() ? 1 : 5;
            });

        return builder;
    }
}
