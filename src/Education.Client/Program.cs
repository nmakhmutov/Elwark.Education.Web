using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Education.Client.Extensions;
using Education.Client.Features.Customer.Services;
using Education.Client.Services;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging
    .SetMinimumLevel(builder.HostEnvironment.IsDevelopment() ? LogLevel.None : LogLevel.Critical);

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

builder.AddInfrastructure()
    .AddCustomerFeature()
    .AddHistoryFeature();

builder.Services
    .AddScoped<ContentFormatter>()
    .AddScoped<CustomerStateProvider>();

await using var app = builder.Build();

await app.Services.GetRequiredService<CustomerHub>()
    .StartAsync();

await app.RunAsync();
