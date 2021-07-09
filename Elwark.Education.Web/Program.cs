using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Elwark.Education.Web.Gateways.Customer;
using Elwark.Education.Web.Gateways.History;
using Elwark.Education.Web.Gateways.Shop;
using Elwark.Education.Web.Infrastructure;
using Elwark.Education.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services
                .AddScoped(_ => new UrlsOptions(
                    new Uri(builder.Configuration["Urls:Gateway"]!),
                    new Uri(builder.Configuration["Urls:Account"]!)
                ))
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddScoped<LanguageService>()
                .AddScoped<TopicContentFormatService>()
                .AddScoped<ThemeService>()
                .AddScoped<EducationAuthorization>()
                .AddScoped<EducationLocalization>()
                .AddScoped<ErrorManager>();

            builder.Services
                .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

            var policy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));

            builder.Services
                .AddHttpClient<IHistoryClient, HistoryClient>(client =>
                    client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"]!))
                // .AddHttpMessageHandler<EducationAuthorization>()
                .AddHttpMessageHandler<EducationLocalization>()
                .AddPolicyHandler(policy);

            builder.Services
                .AddHttpClient<ICustomerClient, CustomerClient>(
                    client => client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"]!))
                .AddHttpMessageHandler<EducationAuthorization>()
                .AddHttpMessageHandler<EducationLocalization>()
                .AddPolicyHandler(policy);

            builder.Services
                .AddHttpClient<IShopClient, ShopClient>(
                    client => client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"]!))
                .AddHttpMessageHandler<EducationAuthorization>()
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

    public sealed record UrlsOptions(Uri Gateway, Uri Account);
}
