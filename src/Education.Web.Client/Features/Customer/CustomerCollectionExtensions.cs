using Education.Web.Client.Features.Customer.Services;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Notification;
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

                return new CustomerHab(builder.Configuration.GetValue<Uri>("Urls:Hub")!, tokenProvider, stateProvider);
            });

        return builder;
    }
}
