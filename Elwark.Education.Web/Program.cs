using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Elwark.Education.Web.Services;
using Elwark.Education.Web.Services.History;
using Elwark.Education.Web.Services.LocalStorage;
using Elwark.Education.Web.Services.User;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace Elwark.Education.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddMudBlazorDialog()
                .AddMudBlazorSnackbar()
                .AddMudBlazorResizeListener()
                .AddBlazoredLocalStorage();

            builder.Services
                .AddScoped(_ => new UrlsOptions(
                    new Uri(builder.Configuration["Urls:Gateway"]),
                    new Uri(builder.Configuration["Urls:Account"])
                ))
                .AddScoped<ILocalStorage, LocalStorage>()
                .AddScoped<ElwarkAuthorizationMessageHandler>()
                .AddScoped<LocalizationMessageHandler>();
            
            builder.Services
                .AddHttpClient<IHistoryService, HistoryService>(
                    client => client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"])
                )
                .AddHttpMessageHandler<ElwarkAuthorizationMessageHandler>()
                .AddHttpMessageHandler<LocalizationMessageHandler>();

            builder.Services
                .AddHttpClient<IUserService, UserService>(
                    client => client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"])
                )
                .AddHttpMessageHandler<ElwarkAuthorizationMessageHandler>()
                .AddHttpMessageHandler<LocalizationMessageHandler>();

            builder.Services
                .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

            builder.Services
                .AddLocalization(options => options.ResourcesPath = "Resources");
            
            await builder.Build()
                .RunAsync();
        }
    }

    public sealed record UrlsOptions(Uri Gateway, Uri Account);
}