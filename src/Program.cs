using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web;
using Education.Web.Components.Customer;
using Education.Web.Services.Api;
using Education.Web.Services.Customer;
using Education.Web.Services.History.EventGuesser;
using Education.Web.Services.History.Leaderboard;
using Education.Web.Services.History.Search;
using Education.Web.Services.History.Test;
using Education.Web.Services.History.Topic;
using Education.Web.Services.History.Trend;
using Education.Web.Services.History.User;
using Education.Web.Services.Notification;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

if (builder.HostEnvironment.IsProduction())
    builder.Logging.ClearProviders();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddMudServices(options =>
    {
        options.SnackbarConfiguration.PreventDuplicates = false;
        options.SnackbarConfiguration.NewestOnTop = true;
        options.SnackbarConfiguration.ShowCloseIcon = true;
        options.SnackbarConfiguration.MaxDisplayedSnackbars = 4;
        options.SnackbarConfiguration.SnackbarVariant = Variant.Text;
    })
    .AddBlazoredLocalStorage(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services
    .AddOidcAuthentication(options =>
    {
        builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions);

        options.ProviderOptions.DefaultScopes.Clear();
        options.ProviderOptions.DefaultScopes.Add("openid");
        options.ProviderOptions.DefaultScopes.Add("elwark.education.web");
        options.ProviderOptions.DefaultScopes.Add("elwark.education.hub");
    });

var gatewayUrl = builder.Configuration.GetValue<Uri>("Urls:Gateway")!;
var policy = HttpPolicyExtensions.HandleTransientHttpError()
    .WaitAndRetryAsync(builder.HostEnvironment.IsDevelopment() ? 0 : 5, i => TimeSpan.FromSeconds(i));

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
    .AddPolicyHandler(policy);

builder.Services
    .AddHttpClient<ApiAuthenticatedClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<LocalizationHandler>()
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddPolicyHandler(policy);

builder.Services
    .AddScoped<ApiClient>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<INotificationService, NotificationService>()
    .AddScoped<IHistoryEventGuesserService, HistoryEventGuesserService>()
    .AddScoped<IHistoryLeaderboardService, HistoryLeaderboardService>()
    .AddScoped<IHistorySearchService, HistorySearchService>()
    .AddScoped<IHistoryTestService, HistoryTestService>()
    .AddScoped<IHistoryTopicService, HistoryTopicService>()
    .AddScoped<IHistoryTrendService, HistoryTrendService>()
    .AddScoped<IHistoryUserService, HistoryUserService>()
    .AddScoped(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var stateProvider = provider.GetRequiredService<AuthenticationStateProvider>();

        return new CustomerHab(builder.Configuration.GetValue<Uri>("Urls:Hub")!, tokenProvider, stateProvider);
    });

builder.Services
    .AddScoped<CustomerStateProvider>();

var app = builder.Build();

await app.Services.GetRequiredService<CustomerHab>()
    .InitAsync();

await app.RunAsync();
