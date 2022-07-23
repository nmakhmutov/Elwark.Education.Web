using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web;
using Education.Web.Components.Customer;
using Education.Web.Services;
using Education.Web.Services.Api;
using Education.Web.Services.Customer;
using Education.Web.Services.History.EventGuesser;
using Education.Web.Services.History.Home;
using Education.Web.Services.History.Leaderboard;
using Education.Web.Services.History.Test;
using Education.Web.Services.History.Topic;
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
    .AddLocalization(options => options.ResourcesPath = "Resources")
    .AddOidcAuthentication(options =>
    {
        options.ProviderOptions.DefaultScopes.Clear();
        builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions);
    });

var gatewayUrl = builder.Configuration.GetValue<Uri>("Urls:Gateway")!;
var policy = builder.HostEnvironment.IsDevelopment()
    ? HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(new[] { TimeSpan.Zero })
    : HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(5, i => TimeSpan.FromSeconds(i));

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
    .AddScoped<IHistoryService, HistoryService>()
    .AddScoped<IHistoryLeaderboardService, HistoryLeaderboardService>()
    .AddScoped<IHistoryTestService, HistoryTestService>()
    .AddScoped<IHistoryTopicService, HistoryTopicService>()
    .AddScoped<IHistoryUserService, HistoryUserService>()
    .AddScoped(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var stateProvider = provider.GetRequiredService<AuthenticationStateProvider>();

        return new CustomerHab(builder.Configuration.GetValue<Uri>("Urls:Hub")!, tokenProvider, stateProvider);
    });

builder.Services
    .AddScoped<TopicContentFormatService>()
    .AddScoped<CustomerStateProvider>()
    .AddScoped<LocalizationHandler>()
    .AddScoped<AuthorizationMessageHandler>(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var navigation = provider.GetRequiredService<NavigationManager>();

        return new AuthorizationMessageHandler(tokenProvider, navigation)
            .ConfigureHandler(new[] { gatewayUrl.ToString() });
    });

var app = builder.Build();

await app.RunAsync();
