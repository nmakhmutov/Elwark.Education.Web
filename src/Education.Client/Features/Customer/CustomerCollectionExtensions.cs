using Education.Client.Features.Customer.Services;
using Education.Client.Features.Customer.Services.Account;
using Education.Client.Features.Customer.Services.Notification;
using Education.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

internal static class CustomerCollectionExtensions
{
    public static WebAssemblyHostBuilder AddCustomerFeature(this WebAssemblyHostBuilder builder)
    {
        builder.Services
            .AddScoped<CustomerApiClient>()
            .AddScoped<IAccountClient, AccountClient>()
            .AddScoped<INotificationService, NotificationService>()
            .AddScoped(provider =>
            {
                var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
                var stateProvider = provider.GetRequiredService<AuthenticationStateProvider>();

                return new CustomerHub(builder.Configuration.GetValue<Uri>("Urls:Hub")!, tokenProvider, stateProvider);
            })
            .AddTransient<IStartupService>(provider => provider.GetRequiredService<INotificationService>())
            .AddTransient<IStartupService>(provider => provider.GetRequiredService<CustomerHub>());

        return builder;
    }
}
