using System.Text.Json;
using Blazored.LocalStorage;
using Education.Web;
using Education.Web.Gateways.Customers;
using Education.Web.Gateways.History;
using Education.Web.Hubs.Notification;
using Education.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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
var policy = builder.HostEnvironment.IsDevelopment()
    ? HttpPolicyExtensions.HandleTransientHttpError()
        .WaitAndRetryAsync(1, _ => TimeSpan.Zero)
    : HttpPolicyExtensions.HandleTransientHttpError()
        .WaitAndRetryAsync(new[]
        {
            TimeSpan.Zero,
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5)
        });

builder.Services
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddScoped<ThemeService>()
    .AddScoped<SidebarService>()
    .AddScoped<LanguageService>()
    .AddScoped<TopicContentFormatService>()
    .AddScoped<CustomerService>()
    .AddScoped<LocalizationHandler>()
    .AddScoped(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var stateProvider = provider.GetRequiredService<AuthenticationStateProvider>();

        return new NotificationHub(builder.Configuration.GetValue<Uri>("Urls:Hub"), tokenProvider, stateProvider);
    })
    .AddScoped<AuthorizationMessageHandler>(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var navigation = provider.GetRequiredService<NavigationManager>();

        return new AuthorizationMessageHandler(tokenProvider, navigation)
            .ConfigureHandler(new[] { gatewayUrl.ToString() });
    });

builder.Services
    .AddOidcAuthentication(options => builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions));

builder.Services
    .AddHttpClient<IHistoryClient, HistoryClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddHttpMessageHandler<LocalizationHandler>()
    .AddPolicyHandler(policy);

builder.Services
    .AddHttpClient<ICustomerClient, CustomerClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddHttpMessageHandler<LocalizationHandler>()
    .AddPolicyHandler(policy);

await builder.Build().RunAsync();
