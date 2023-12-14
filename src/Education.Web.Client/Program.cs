using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Web.Client.Features.Customer.Services;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Notification;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Course;
using Education.Web.Client.Features.History.Services.DateGuesser;
using Education.Web.Client.Features.History.Services.Exchange;
using Education.Web.Client.Features.History.Services.Flow;
using Education.Web.Client.Features.History.Services.Leaderboard;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Order;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Search;
using Education.Web.Client.Features.History.Services.Store;
using Education.Web.Client.Features.History.Services.User;
using Education.Web.Client.Http;
using Education.Web.Client.Http.Handlers;
using Education.Web.Client.Services;
using Education.Web.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging
    .SetMinimumLevel(builder.HostEnvironment.IsDevelopment() ? LogLevel.Information : LogLevel.Critical);

builder.Services
    .AddMudServices(options =>
    {
        options.SnackbarConfiguration.NewestOnTop = true;
        options.SnackbarConfiguration.ShowCloseIcon = true;
        options.SnackbarConfiguration.MaxDisplayedSnackbars = 4;
        options.SnackbarConfiguration.PreventDuplicates = false;
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
    .AddStandardResilienceHandler(options =>
    {
        options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
        options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
        options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(2);
        options.Retry.UseJitter = true;
        options.Retry.MaxRetryAttempts = builder.HostEnvironment.IsDevelopment() ? 1 : 5;
    });

builder.Services
    .AddHttpClient<ApiAuthenticatedClient>(client => client.BaseAddress = gatewayUrl)
    .AddHttpMessageHandler<LocalizationHandler>()
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .AddStandardResilienceHandler(options =>
    {
        options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(1);
        options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
        options.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(2);
        options.Retry.UseJitter = true;
        options.Retry.MaxRetryAttempts = builder.HostEnvironment.IsDevelopment() ? 1 : 5;
    });

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
    .AddScoped<IHistoryArticleService, HistoryArticleService>()
    .AddScoped<IHistoryCourseService, HistoryCourseService>()
    .AddScoped<IHistoryDateGuesserService, HistoryDateGuesserService>()
    .AddScoped<IHistoryExchangeService, HistoryExchangeService>()
    .AddScoped<IHistoryFlowService, HistoryFlowService>()
    .AddScoped<IHistoryLeaderboardService, HistoryLeaderboardService>()
    .AddScoped<IHistoryLearnerService, HistoryLearnerService>()
    .AddScoped<IHistoryOrderService, HistoryOrderService>()
    .AddScoped<IHistorySearchService, HistorySearchService>()
    .AddScoped<IHistoryStoreService, HistoryStoreService>()
    .AddScoped<IHistoryQuizService, HistoryQuizService>()
    .AddScoped<IHistoryUserService, HistoryUserService>();

builder.Services
    .AddScoped<ContentFormatter>()
    .AddScoped<CustomerStateProvider>();

await using var app = builder.Build();

await app.Services.GetRequiredService<CustomerHab>()
    .StartAsync();

await app.RunAsync();
