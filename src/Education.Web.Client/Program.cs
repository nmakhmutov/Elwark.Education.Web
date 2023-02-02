using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web.Client.Features.Customer.Services;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Notification;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.EventGuesser;
using Education.Web.Client.Features.History.Services.Leaderboard;
using Education.Web.Client.Features.History.Services.Order;
using Education.Web.Client.Features.History.Services.Search;
using Education.Web.Client.Features.History.Services.Store;
using Education.Web.Client.Features.History.Services.Test;
using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Http;
using Education.Web.Client.Http.Handlers;
using Education.Web.Client.Shared.State.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

if (builder.HostEnvironment.IsProduction())
    builder.Logging.ClearProviders();

// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");

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
    .AddScoped<CorrelationHandler>()
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
    .AddHttpMessageHandler<CorrelationHandler>()
    .AddPolicyHandler(policy);

builder.Services
    .AddHttpClient<ApiAuthenticatedClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<LocalizationHandler>()
    .AddHttpMessageHandler<CorrelationHandler>()
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddPolicyHandler(policy);

builder.Services
    .AddScoped<CustomerApiClient>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<INotificationService, NotificationService>()
    .AddScoped(provider =>
    {
        var tokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
        var stateProvider = provider.GetRequiredService<AuthenticationStateProvider>();

        return new CustomerHab(builder.Configuration.GetValue<Uri>("Urls:Hub")!, tokenProvider, stateProvider);
    });

builder.Services
    .AddScoped<HistoryApiClient>()
    .AddScoped<IHistoryEventGuesserService, HistoryEventGuesserService>()
    .AddScoped<IHistoryLeaderboardService, HistoryLeaderboardService>()
    .AddScoped<IHistorySearchService, HistorySearchService>()
    .AddScoped<IHistoryStoreService, HistoryStoreService>()
    .AddScoped<IHistoryOrderService, HistoryOrderService>()
    .AddScoped<IHistoryTestService, HistoryTestService>()
    .AddScoped<IHistoryArticleService, HistoryArticleService>()
    .AddScoped<IHistoryUserService, HistoryUserService>();

builder.Services
    .AddScoped<CustomerStateProvider>();

var app = builder.Build();

await app.Services.GetRequiredService<CustomerHab>()
    .InitAsync();

await app.RunAsync();
