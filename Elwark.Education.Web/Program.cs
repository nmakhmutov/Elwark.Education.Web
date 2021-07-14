using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Elwark.Education.Web.Gateways.Customer;
using Elwark.Education.Web.Gateways.History;
using Elwark.Education.Web.Gateways.Shop;
using Elwark.Education.Web.Infrastructure;
using Elwark.Education.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Logging;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;

namespace Elwark.Education.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddMudServices()
                .AddBlazoredLocalStorage();

            var gatewayUrl = builder.Configuration.GetValue<Uri>("Urls:Gateway");

            builder.Services
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddScoped<LanguageService>()
                .AddScoped<TopicContentFormatService>()
                .AddScoped<ThemeService>()
                .AddScoped<AuthorizationMessageHandler>(provider =>
                    new AuthorizationMessageHandler(
                            provider.GetRequiredService<IAccessTokenProvider>(),
                            provider.GetRequiredService<NavigationManager>()
                        )
                        .ConfigureHandler(new[] {gatewayUrl.ToString()})
                )
                .AddScoped<EducationLocalization>()
                .AddScoped<ErrorManager>();

            builder.Services
                .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

            var policy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));

            builder.Services
                .AddHttpClient<IHistoryClient, HistoryClient>(client => client.BaseAddress = gatewayUrl)
                .AddHttpMessageHandler<AuthorizationMessageHandler>()
                .AddHttpMessageHandler<EducationLocalization>()
                .AddPolicyHandler(policy);

            builder.Services
                .AddHttpClient<ICustomerClient, CustomerClient>(client => client.BaseAddress = gatewayUrl)
                .AddHttpMessageHandler<AuthorizationMessageHandler>()
                .AddHttpMessageHandler<EducationLocalization>()
                .AddPolicyHandler(policy);

            builder.Services
                .AddHttpClient<IShopClient, ShopClient>(client => client.BaseAddress = gatewayUrl)
                .AddHttpMessageHandler<AuthorizationMessageHandler>()
                .AddHttpMessageHandler<EducationLocalization>()
                .AddPolicyHandler(policy);

            var host = builder.Build();

            await host.Services.GetRequiredService<TopicContentFormatService>()
                .InitAsync();

            await host.Services.GetRequiredService<ThemeService>()
                .InitAsync();

            await host.RunAsync();
        }
    }
}
