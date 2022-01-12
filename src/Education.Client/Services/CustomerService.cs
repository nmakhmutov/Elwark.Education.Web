using Blazored.LocalStorage;
using Education.Client.Features;
using Education.Client.Gateways.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Client.Services;

public sealed class CustomerService
{
    private const string StorageKey = "cs";
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ICustomerClient _customerClient;
    private readonly NavigationManager _navigation;
    private readonly ILocalStorageService _storage;

    public CustomerService(ICustomerClient customerClient, ILocalStorageService storage,
        AuthenticationStateProvider authenticationStateProvider, NavigationManager navigation)
    {
        _customerClient = customerClient;
        _storage = storage;
        _authenticationStateProvider = authenticationStateProvider;
        _navigation = navigation;
    }

    public async Task InitAsync()
    {
        if (await _storage.ContainKeyAsync(StorageKey))
            return;

        var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == true)
            _navigation.NavigateTo(Links.Authentication.LogIn(Uri.EscapeDataString(_navigation.Uri)));
    }

    public async Task CreateAsync()
    {
        if (await _storage.ContainKeyAsync(StorageKey))
            return;

        await _customerClient.CreateAsync();
        await _storage.SetItemAsync(StorageKey, Guid.NewGuid());
    }
}
