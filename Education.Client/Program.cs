using System;
using System.Text.Json;
using Blazored.LocalStorage;
using Education.Client;
using Education.Client.Gateways.Customer;
using Education.Client.Gateways.History;
using Education.Client.Gateways.Store;
using Education.Client.Infrastructure;
using Education.Client.Infrastructure.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddMudServices(configuration =>
    {
        configuration.SnackbarConfiguration.PreventDuplicates = false;
        configuration.SnackbarConfiguration.NewestOnTop = true;
        configuration.SnackbarConfiguration.MaxDisplayedSnackbars = 3;
    })
    .AddBlazoredLocalStorage(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    });

var gatewayUrl = builder.Configuration.GetValue<Uri>("Urls:Gateway");
var policy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));

builder.Services
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddScoped<LanguageService>()
    .AddScoped<TopicContentFormatService>()
    .AddScoped<ThemeService>()
    .AddScoped<SidebarService>()
    .AddScoped<AuthorizationMessageHandler>(provider =>
        new AuthorizationMessageHandler(
                provider.GetRequiredService<IAccessTokenProvider>(),
                provider.GetRequiredService<NavigationManager>()
            )
            .ConfigureHandler(new[] { gatewayUrl.ToString() })
    )
    .AddScoped<EducationLocalization>();

builder.Services
    .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

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
    .AddHttpClient<IStoreClient, StoreClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddHttpMessageHandler<EducationLocalization>()
    .AddPolicyHandler(policy);

await builder.Build().RunAsync();
