using System;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.History;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
                .AddMudBlazorResizeListener();

            builder.Services
                .AddScoped(_ => new UrlsOptions(
                    new Uri(builder.Configuration["Urls:Gateway"]),
                    new Uri(builder.Configuration["Urls:Account"])
                ))
                .AddHttpClient<IHistoryService, HistoryService>(client =>
                    client.BaseAddress = new Uri(builder.Configuration["Urls:Gateway"])
                )
                .AddHttpMessageHandler(provider =>
                    provider.GetRequiredService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            new[] {builder.Configuration["Urls:Gateway"]},
                            new[] {"elwark.education.web"}
                        )
                );

            builder.Services
                .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

            await builder.Build().RunAsync();
        }
    }

    public sealed record UrlsOptions(Uri Gateway, Uri Account);
}